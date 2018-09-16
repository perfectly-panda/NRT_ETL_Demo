<template>
    <span v-if="countFrom">{{this.now - (new Date(countFrom+'Z')) | formatDuration}}</span>
</template>

<script>
export default {
  name: 'Timer',
  props: {
    countFrom: null
  },
  data: function(){
    return {
      interval: null,
      now: null
    }
  },
  mounted: function () {
    this.interval = setInterval(this.onTimer, 1000);
  },
  methods: {
    onTimer() {
      this.now = Date.now();
    }
  }
}
</script>