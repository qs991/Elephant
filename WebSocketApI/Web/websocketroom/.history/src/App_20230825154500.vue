<template>
  <div class="mainDiv">
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span>简易聊天室</span>
        </div>
      </template>
      <el-input v-model="msglist" type="textarea" />
      <div style="padding: 14px">
        <div class="bottom">
          <el-input />
          <el-button text class="button">发送</el-button>
        </div>
      </div>
    </el-card>
  </div>
</template>
<script>
import { defineComponent } from "@vue/composition-api";

export default defineComponent({
  setup() {
    return {};
  },
});
</script>

<style>
.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.box-card {
  width: 50%;
  height: 600px;
}
.mainDiv {
  width: 100%;
  height: 800px;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>