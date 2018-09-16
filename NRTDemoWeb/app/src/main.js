import Vue from 'vue'
import App from './App.vue'

import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.css'

import moment from 'moment'

Vue.use(Vuetify);

Vue.config.productionTip = false;

Vue.filter('formatDate', function(value) {
  if (value) {
    return moment.utc(String(value)).local().format('MM/DD/YYYY hh:mm')
  }
});

Vue.filter('formatDuration', function(value) {
  if (value) {
    return moment.utc(value).format('HH:mm:ss');
  }
});

new Vue({
  render: h => h(App)
}).$mount('#app')


