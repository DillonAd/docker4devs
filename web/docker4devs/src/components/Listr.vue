<template>
  <div>
    <div class="row">
      <form v-on:submit="send">
        <input type="text" v-model="val" />
        <input type="submit" value="Send!" />
      </form>
    </div>
    <div class="row">
      <ul>
        <li v-for="item in valueList" v-bind:key="item.id">{{ item.id }} : {{ item.name }}</li>
      </ul>
    </div>
  </div>
</template>

<script>

export default {
  name: 'Listr',
  data: () => {
    return {
      val: '',
      valueList: [],
    };
  },
  methods: {
    async send(e) {
      e.preventDefault();
      await new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        
        xhr.addEventListener("load", () => { resolve(xhr.response); });
        xhr.addEventListener("error", () => { reject(); });
        xhr.addEventListener("abort", () => { reject(); });

        xhr.open('POST', 'http://localhost:5000/api/values');
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.send(JSON.stringify({ name: this.val }));
      });

      this.val = '';

      await this.query();
    },
    async query() {
      const items = await new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        
        xhr.addEventListener("load", () => { resolve(xhr.response); });
        xhr.addEventListener("error", () => { reject(); });
        xhr.addEventListener("abort", () => { reject(); });

        xhr.open('GET', 'http://localhost:5000/api/values');
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.send();
      });

      this.valueList = JSON.parse(items);
    }
  },
  async mounted() {
    await this.query();
  },
}
</script>

<style scoped>
  .row {
    width: 100%;
  }
</style>
