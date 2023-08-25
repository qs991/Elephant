<template>
  <div class="mainDiv">
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span>简易聊天室</span>
        </div>
      </template>
      <el-input class="msgList" type="textarea" />
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
import { ref } from "vue";

let msglist = ref("");
let roomNo = ref("");
let NickName = ref("");
let message = ref("");
const server = "ws://localhost:5137";
const WEB_SOCKET = new WebSocket(server + "/ws");
WEB_SOCKET.onopen = (evt) => {
  console.log("Connection open ...");
  msgList = "websocket connection opened .";
};
WEB_SOCKET.onmessage = (evt) => {
  console.log("Received Message: " + evt.data);
  if (evt.data) {
    msglist = msglist + "\r\n" + evt.data;
  }
};
WEB_SOCKET.onclose = (evt) => {
  console.log("Connection closed.");
};
const join = () => {
  if (roomNo) {
    var msg = {
      action: "join",
      msg: roomNo,
      nick: NickName,
    };
    WEB_SOCKET.send(JSON.stringify(msg));
  }
};
const send = () => {
  if (message.value) {
    WEB_SOCKET.send(
      JSON.stringify({
        action: "send",
        msg: message.value,
        nick: NickName,
      })
    );
  }
};
const leave = () => {
  var nick = $("#txtNickName").val();
  var msg = {
    action: "leave",
    msg: "",
    nick: nick,
  };
  WEB_SOCKET.send(JSON.stringify(msg));
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
#msgList {
  height: 80%;
}
</style>