<template>
  <div class="mainDiv">
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span>简易聊天室</span>
        </div>
      </template>
      <el-input v-model="msg" type="textarea" />
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
import { reactive, toRefs } from "vue";

export default {
  setup() {
    const state = reactive({
      msg: "数据",
      roomNo: "",
      NickName: "",
      message: "",
    });
    const server = "ws://localhost:5137";
    const WEB_SOCKET = new WebSocket(server + "/ws");
    WEB_SOCKET.onopen = (evt) => {
      console.log("Connection open ...");
      state.msg = "websocket connection opened .";
    };
    WEB_SOCKET.onmessage = (evt) => {
      console.log("Received Message: " + evt.data);
      if (evt.data) {
        state.msg = state.msglist + "\r\n" + evt.data;
      }
    };
    WEB_SOCKET.onclose = (evt) => {
      console.log("Connection closed.");
    };
    const join = () => {
      if (state.roomNo) {
        var msg = {
          action: "join",
          msg: state.roomNo,
          nick: state.NickName,
        };
        WEB_SOCKET.send(JSON.stringify(msg));
      }
    };
    const send = () => {
      if (state.message) {
        WEB_SOCKET.send(
          JSON.stringify({
            action: "send",
            msg: state.message,
            nick: state.NickName,
          })
        );
      }
    };
    const leave = () => {
      var msg = {
        action: "leave",
        msg: "",
        nick: state.NickName,
      };
      WEB_SOCKET.send(JSON.stringify(msg));
    };
    return {
      ...toRefs(state),
      leave,
      send,
      join,
    };
  },
};
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