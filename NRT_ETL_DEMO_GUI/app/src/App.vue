<template>
  <div id="app">
    <TruckList></TruckList>
  </div>
</template>

<script>
import TruckList from './components/TruckList.vue'

export default {
  name: 'app',
  components: {
    TruckList
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
