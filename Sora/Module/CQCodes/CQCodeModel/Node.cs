using System.Collections.Generic;
using Newtonsoft.Json;
using Sora.Module.ApiMessageModel;

namespace Sora.Module.CQCodes.CQCodeModel
{
    /// <summary>
    /// 自定义合并转发节点
    /// </summary>
    public struct Node
    {
        #region 属性
        /// <summary>
        /// 发送者昵称
        /// </summary>
        [JsonProperty(PropertyName = "sender")]
        public NodeSender Sender { get; set; }

        /// <summary>
        /// 发送事件戳
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        internal List<ApiMessage> MessageList { get; set; }

        /// <summary>
        /// CQList
        /// </summary>
        [JsonIgnore]
        public List<CQCode> CQCodeMsgList { get; set; }
        #endregion

        #region 发送者结构体
        /// <summary>
        /// 节点消息发送者
        /// </summary>
        public struct NodeSender
        {
            /// <summary>
            /// 发送者昵称
            /// </summary>
            [JsonProperty(PropertyName = "nickname")]
            internal string Nick { get; set; }

            /// <summary>
            /// UID
            /// </summary>
            [JsonProperty(PropertyName = "user_id")]
            internal long Uid { get; set; }
        }
        #endregion
    }
}