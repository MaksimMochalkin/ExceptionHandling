using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            string message = null;
            try
            {
                var task = new UserTask(description);
                int result = _taskService.AddTaskForUser(userId, task);
                if (result == -1)
                {
                    throw new FormatException("Invalid userId");
                }

                if (result == -2)
                {
                    throw new KeyNotFoundException("User not found");
                }
                   

                if (result == -3)
                {
                    throw new DuplicateNameException("The task already exists");
                }
            }
            catch (FormatException e)
            {
                return message = e.Message;
            }
            catch (KeyNotFoundException e)
            {
                return message = e.Message;
            }
            catch (DuplicateNameException e)
            {
                return message = e.Message;
            }


            return message;
        }
    }
}