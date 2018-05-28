<template>
  <div>
    <md-dialog :md-active.sync="remote.showDialog">
      <md-dialog-title>Thank you</md-dialog-title>
          <div class="content">{{remote.rating}} Thank you for using this service. We would appreciate your feedback by answering this question.</div>
          <md-dialog-content>
          <md-toolbar :md-elevation="1">
            <span class="md-subheading">How likely would you be to recommend this service to others?</span>
          </md-toolbar>
          <!--<md-subheader>How likely would you be to recommend this service to others?</md-subheader>-->
          <div class="md-layout content">
          <md-radio class="md-layout-item md-medium-size-100 md-small-size-100" v-model="radio" value="1">Very unlikely</md-radio>
          <md-radio class="md-layout-item md-medium-size-100 md-small-size-100" v-model="radio" value="2">Unlikely</md-radio>
          <md-radio class="md-layout-item md-medium-size-100 md-small-size-100" v-model="radio" value="3">Neutral</md-radio>
          <md-radio class="md-layout-item md-medium-size-100 md-small-size-100" v-model="radio" value="4">Likely</md-radio>
          <md-radio class="md-layout-item md-small-size-100 md-small-size-100" v-model="radio" value="5">Very likely</md-radio>
          </div>

          <md-toolbar :md-elevation="1">
            <span class="md-subheading">{{getFeedbackQuestionText()}}</span>
          </md-toolbar>
          <div class="md-layout content">
          <div class="md-layout-item">
            <md-field>
              <label>Textarea</label>
              <md-textarea v-model="suggestions" maxlength="200" md-counter="200"></md-textarea>
            </md-field>
          </div>
          </div>
          </md-dialog-content>
      <md-dialog-actions>
        <md-button class="md-primary" @click="remote.showDialog = false">Never Mind</md-button>
        <md-button class="md-primary" @click="submit">Submit</md-button>
      </md-dialog-actions>
    </md-dialog>

    <!--<md-button class="md-primary md-raised" @click="remote.showDialog = true">Show Dialog</md-button>-->
  </div>
</template>

<script>
import remoteService from "../services/appratingshared.js"
export default {
  name: "Dialogue",
  data: () => ({
    remote: remoteService,
    //showDialog: false,
    radio: 0,
    suggestions: null
  }),
  methods: {
    submit: function(){
      this.$http.post("https://demo7929858.mockable.io/",
          {
            "rating": this.remote.rating,
            "recommendationRating": this.radio,
            "suggestions": this.suggestions
          })
            .then(result => console.log(result.data))
            .catch(error => console.log(error));
    }
  },
    getFeedbackQuestionText: function(){
        if(this.remote.rating < 5){
          return "What can we do to  improve?";
        }
        else if(this.remote.rating < 9){
          return "Is there anything we can do to improve?";
        }
        else{
          return "Is there anything you particularly like?";
        }
    }
}
</script>

<style lang="scss" scoped>
.md-dialog {
  max-width: 768px;
}
small {
  display: block;
}

.content {
  padding: 16px;
}

</style>
