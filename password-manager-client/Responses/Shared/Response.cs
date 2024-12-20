﻿using System.Net;

namespace password_manager_client.Responses.Shared
{
    public class Response<T>
    {
        #region Properties

        public T Data { get; set; }
        public bool Succeeded { get; set; } = true;
        public Dictionary<string, List<string>> Errors { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; } = 200;

        #endregion Properties

        #region Ctor

        public Response()
        {
        }

        public Response(T data, string message = null, int statusCode = (int)HttpStatusCode.OK)
        {
            Succeeded = true;
            Message = message;
            Errors = null;
            Data = data;
            StatusCode = statusCode;
        }

        public Response(T data, bool succeeded, string message = null, int statusCode = (int)HttpStatusCode.OK)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = null;
            Data = data;
            StatusCode = statusCode;
        }

        #region Error Results

        public void AddError(string key, string error)
        {
            if (Errors.ContainsKey(key))
            {
                Errors[key].Add(error);
            }
            else
            {
                Errors.Add(key, new List<string> { error });
            }
        }

        public void AddErrors(string key, List<string> errors)
        {
            if (Errors != null && Errors.ContainsKey(key))
            {
                Errors[key].AddRange(errors);
            }
            else
            {
                if (Errors == null)
                {
                    Errors = new Dictionary<string, List<string>>();
                    Errors.Add(key, errors);
                }
                else
                {
                    Errors.Add(key, errors);
                }
            }
        }

        public void AddErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var error in errors)
            {
                AddErrors(error.Key, error.Value);
            }
        }

        #endregion Error Results

        #region Status Results

        public Response<T> Forbidden(string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.Forbidden;
            return this;
        }

        public Response<T> InternalServerError(string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.InternalServerError;
            return this;
        }

        public Response<T> NotFound(string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.NotFound;
            return this;
        }

        public Response<T> BadRequest(string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.BadRequest;
            return this;
        }

        public Response<T> NoContent(T data, string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.NoContent;
            return this;
        }

        public Response<T> Ok(T data)
        {
            StatusCode = (int)HttpStatusCode.OK;
            Succeeded = true;
            Data = data;

            return this;
        }

        public Response<T> UnAuthorized(string message = null)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.Unauthorized;
            return this;
        }

        #endregion Status Results

        #endregion Ctor
    }
}
