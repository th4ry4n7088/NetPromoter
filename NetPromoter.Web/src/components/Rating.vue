<template>
  <div class="star-rating">
    <label class="star-rating__star" v-for="rating in ratings" 
        :class="{'is-selected': ((ratingValue >= rating) && ratingValue != null), 'is-disabled': disabled}" 
        v-on:click="set_rating(rating)" v-on:mouseover="star_over(rating)" 
        v-on:mouseout="star_out">
      <input class="star-rating star-rating__checkbox" type="radio" 
          :value="rating" :name="name" v-model="ratingValue" :disabled="disabled">★
    </label>
  </div>
</template>

<script>
import remoteService from "../services/appratingshared.js"

export default {
  name: "Rating",
  props:{
    value: null,
    disabled: Boolean,
    showFeedback: Boolean,
    pageId: null
  },
  computed: {
    ratingValue: {
      get: function(){
        if(this.rating == null){
          this.rating = this.value;
        }
        return this.rating;
      },
      set: function(val){
        this.rating = val;
      }
    }
  },
  data: () => ({
    name: null,
    rating: null,
    temp_value: null,
    ratings: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
  }),

  methods: {
    /*
     * Behaviour of the stars on mouseover.
     */
    star_over: function (index) {
      var self = this;

      if (!this.disabled) {
        this.temp_value = this.ratingValue;
        return this.ratingValue = index;
      }

    },

    /*
     * Behaviour of the stars on mouseout.
     */
    star_out: function () {
      var self = this;

      if (!this.disabled) {
        return this.ratingValue = this.temp_value;
      }
    },

    /*
     * Set the rating.
     */
    set_rating: function (value) {
      var self = this;

      if (!this.disabled) {
        this.temp_value = value;
        this.ratingValue = value;
        remoteService.rating = value;

        if(this.showFeedback) {
          remoteService.showDialog = true;
        }
        else {
          this.$http.post("https://demo7929858.mockable.io/",
          {
            "rating": this.ratingValue,
            "pageId": this.pageId
          })
            .then(result => console.log(result.data))
            .catch(error => console.log(error));
        }
      }
    }
  }
};
</script>

<style lang="scss" scoped>
	%visually-hidden {
		position: absolute;
		overflow: hidden;
		clip: rect(0 0 0 0);
		height: 1px;
		width: 1px;
		margin: -1px;
		padding: 0;
		border: 0;
	}

	.star-rating {
		&__star {
			display: inline-block;
			padding: 3px;
			vertical-align: middle;
			line-height: 1;
			font-size: 1.5em;
			color: #ABABAB;
			transition: color .2s ease-out;
			&:hover {
				cursor: pointer;
			}
			&.is-selected {
				color: #FFD700;
			}
			&.is-disabled:hover {
				cursor: default;
			}
		}
		&__checkbox {
			@extend %visually-hidden;
		}
	}
</style>
