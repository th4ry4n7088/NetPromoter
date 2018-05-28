// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import VueResource from "vue-resource"
import VueMaterial from "vue-material"

import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

import AppRating from "./AppRating";
import PageRating from "./PageRating";

Vue.config.productionTip = false;
Vue.use(VueMaterial);
Vue.use(VueResource);

/* eslint-disable no-new */
if (document.getElementsByTagName("AppRating").length > 0) {
  new Vue({
    el: "AppRating",
    components: { AppRating },
    template: "<AppRating/>"
  });
}

if (document.getElementsByTagName("PageRating").length > 0) {
  new Vue({
    el: "PageRating",
    components: { PageRating },
    template: "<PageRating/>"
  });
}