<template>
  <div class="appRating">
    <Dialogue />
	<h3>App's User Ratings</h3>
    <Rating value="6" :disabled="true" />
	<h3>Submit Your Rating</h3>
    <Rating :showFeedback="true" />
  </div>
</template>

<script>
import Dialogue from "./components/Dialogue";
import Rating from "./components/Rating";

export default {
  name: "AppRating",
  components: {
    Dialogue,
    Rating
  }
};
</script>

<style>
/*.appRating {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}*/
</style>
