using System;
using System.Collections.Generic;

namespace CheckoutTest.Core.Framework
{ 
    public class TaskResult
    {
        public TaskResult()
        {
            Messages = new List<string>();
        }
        /// <summary>
        /// Determine if a Task has been executed Succesfully
        /// </summary>
        public bool ExecutedSuccesfully { get; set; }
        /// <summary>
        /// Summary of messages. This can include error messages (if ExecutedSuccesfully = false) or
        /// a result message (if ExecutedSuccesfully = true)
        /// </summary>
        public string Message
        {
            get
            {
                var result = "";
                if (Exception != null)
                {
                    AddErrorMessage("We had problems trying to perform this task, contact your administrator.");
                    AddErrorMessage(Exception.ToString());

                    if (Exception.InnerException != null)
                    {
                        AddErrorMessage(Exception.InnerException.ToString());
                    }
                }

                if (Messages.Count > 0)
                {

                    result = string.Join(",", Messages);

                    if (result[result.Length - 1] == ',')
                        result = result.Remove(result.Length - 1);
                }
                else
                {
                    result = "";
                }


                return result;
            }
        }
        /// <summary>
        /// List of all messages that were recorded while performing the task
        /// </summary>
        private IList<string> Messages { get; set; }
        /// <summary>
        /// In case we have an exception performing our task
        /// </summary>
        public Exception Exception { get; set; }

        public int CreatedObjectId { get; set; }

        public void AddErrorMessage(string errorMessage)
        {
            ExecutedSuccesfully = false;
            Messages.Add(errorMessage);
        }
        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public TaskResult AsJson()
        {

            var res = new TaskResult
            {
                ExecutedSuccesfully = this.ExecutedSuccesfully,
                Exception = null,
                CreatedObjectId = this.CreatedObjectId
            };

            res.Messages.Add(this.Message);

            return res;
            
        }

    }
}
