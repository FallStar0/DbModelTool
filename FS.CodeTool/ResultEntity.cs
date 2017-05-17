//===================================================
//  作者：Fallstar
//  时间：2016-06-13 17:03:06
//  说明：用于包裹数据结果的实体
//===================================================

namespace FS.CodeTool
{
    using System;
    /// <summary>
    /// 用于包裹数据结果的实体
    /// </summary>
    public class ResultEntity<T>
    {
        #region 字段
        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// 结果是否成功
        /// </summary>
        public bool IsSuccess { get { return ReplyCode == 1000; } set { ReplyCode = value ? 1000 : 9999; } }
        /// <summary>
        /// 如果失败，那么这是具体消息
        /// </summary>
        public string ReplyMsg { get; set; }
        /// <summary>
        /// 错误代码，1000=成功
        /// </summary>
        public int ReplyCode { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// Init
        /// </summary>
        public ResultEntity()
        {
            ReplyCode = 1000;
        }
        /// <summary>
        /// 设置结果为失败
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public ResultEntity<T> SetFail(int errorCode, string message)
        {
            ReplyCode = errorCode;
            ReplyMsg = message;
            return this;
        }
        /// <summary>
        /// 设置结果为失败，但不指定代码
        /// </summary>
        /// <param name="message"></param>
        public ResultEntity<T> SetFail(string message)
        {
            ReplyCode = 9999;
            ReplyMsg = message;
            return this;
        }

        /// <summary>
        /// 设置结果为失败，但不指定代码
        /// </summary>
        /// <param name="message"></param>
        public ResultEntity<T> SetFail(Exception ex, string message = null)
        {
            ReplyCode = 9999;
            ReplyMsg = ex.Message + message;
            return this;
        }

        /// <summary>
        /// 从别的失败结果里面复制失败原因。
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="res"></param>
        /// <returns></returns>
        public ResultEntity<T> SetFail<T2>(ResultEntity<T2> res)
        {
            ReplyCode = res.ReplyCode;
            ReplyMsg = res.ReplyMsg;
            Result = default(T);
            return this;
        }
        #endregion
    }
    /// <summary>
    /// 数据结果实体
    /// </summary>
    public class ResultEntity : ResultEntity<object>
    {
        /// <summary>
        /// 隐藏这个字段
        /// </summary>
        protected new object Result { get; set; }
        /// <summary>
        /// 设置结果为失败
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public new ResultEntity SetFail(int errorCode, string message)
        {
            ReplyCode = errorCode;
            ReplyMsg = message;
            return this;
        }
        /// <summary>
        /// 设置结果为失败，但不指定代码
        /// </summary>
        /// <param name="message"></param>
        public new ResultEntity SetFail(string message)
        {
            ReplyCode = 9999;
            ReplyMsg = message;
            return this;
        }
    }
}
