<template>
  <div class="mainDiv">
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span>简易聊天室</span>
        </div>
      </template>
      <div class="messageTxt"></div>
      <div style="padding: 14px">
        <div class="bottom">
          <el-input />
          <el-button text class="button">发送</el-button>
        </div>
      </div>
    </el-card>
  </div>
</template>
<script setup>
const server = "ws://localhost:5137";
const 
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
.messageTxt {
  width: 100%;
  height: 400px;
  border: 1px solid black;
}
</style>