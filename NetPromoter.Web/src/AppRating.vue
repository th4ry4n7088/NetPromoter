<template>
  <div class="appRating">
    <Dialogue />
	<h2>App's User Ratings</h2>
    <Rating :disabled="true" />
	<h2>Submit Your Rating</h2>
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
