<template>
  <div class="pageRating">
    <Rating key="page-rating" />
  </div>
</template>

<script>
import Rating from "./components/Rating";

export default {
  name: "PageRating",
  components: {
    Rating
  }
};
</script>
