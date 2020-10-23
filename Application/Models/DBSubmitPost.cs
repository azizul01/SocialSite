using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Application.Models
{   
    public class DBSubmitPost
    {
        OutputResult objResult = new OutputResult();
     
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;

        string setSP = "spSet_PostInformation";
        string getSP = "spGet_PostInformation";

        #region Save Data
        private enum SaveOption
        {
            SaveRow = 1, UpdateRow = 2
        }
        public OutputResult SavePost(PostInformation objItem, string UserBy)
        {
            try
            {
                cmd = new SqlCommand(setSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SaveOption", SqlDbType.Int).Value = SaveOption.SaveRow;
                cmd.Parameters.Add("@PostHead", SqlDbType.VarChar).Value = objItem.PostHead; 
                cmd.Parameters.Add("@PostImage", SqlDbType.VarChar).Value = objItem.PostImage;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = objItem.IsActive;
                cmd.Parameters.Add("@UserBy", SqlDbType.VarChar).Value = UserBy;

                SqlParameter paramIdentityValue = new SqlParameter("@IdentityValue", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(paramIdentityValue);

                SqlParameter ErrNo = new SqlParameter("@ErrNo", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(ErrNo);
                DataManager.cnConnection.Open();

                objResult.NoofRows = cmd.ExecuteNonQuery();
                objResult.ErrorNo = int.Parse(cmd.Parameters["@ErrNo"].Value.ToString());
                objResult.ResultId = int.Parse(cmd.Parameters["@IdentityValue"].Value.ToString());

                if (objResult.NoofRows > 0 && objResult.ResultId > 0)
                {
                    objResult.Message = "Save operation successful.";
                }
                else
                {
                    if (objResult.ErrorNo == -1)
                    {
                        objResult.Message = "Save operation failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
                objResult.ResultId = 0;
                objResult.ErrorNo = -1;
                objResult.Message = "Exception: Save operation failed.";
            }
            finally
            {
                DataManager.cnConnection.Close();
                cmd = null;
            }
            return objResult;
        }
        public OutputResult UpdatePost(PostInformation objItem, string UserBy)
        {
            try
            {
                cmd = new SqlCommand(setSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("SaveOption", SqlDbType.Int).Value = SaveOption.UpdateRow;
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = objItem.PostID; 
                cmd.Parameters.Add("@PostHead", SqlDbType.VarChar).Value = objItem.PostHead;
                cmd.Parameters.Add("@PostImage", SqlDbType.VarChar).Value = objItem.PostImage;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = objItem.IsActive;
                cmd.Parameters.Add("@UserBy", SqlDbType.VarChar).Value = UserBy;

                SqlParameter paramIdentityValue = new SqlParameter("@IdentityValue", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(paramIdentityValue);

                SqlParameter ErrNo = new SqlParameter("@ErrNo", SqlDbType.Int, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null);
                cmd.Parameters.Add(ErrNo);
                DataManager.cnConnection.Open();

                objResult.NoofRows = cmd.ExecuteNonQuery();
                objResult.ErrorNo = int.Parse(cmd.Parameters["@ErrNo"].Value.ToString());
                objResult.ResultId = int.Parse(cmd.Parameters["@IdentityValue"].Value.ToString());

                if (objResult.NoofRows > 0 && objResult.ResultId > 0)
                {
                    objResult.Message = "Update operation successful.";
                }
                else
                {
                    if (objResult.ErrorNo == -1)
                    {
                        objResult.Message = "Update operation failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
                objResult.ResultId = 0;
                objResult.ErrorNo = -1;
                objResult.Message = "Exception: Update operation failed.";
            }
            finally
            {
                DataManager.cnConnection.Close();
                cmd = null;
            }
            return objResult;
        }

        #endregion

        #region Load Data

        int LoadPostInformation = 1,
            LoadPostFeedBack = 2;
        private List<PostInformation> GetData(int LoadOption, PostInformation ObjItem, string UserID)
        {
            List<PostInformation> listData = new List<PostInformation>();
            try
            {
                cmd = new SqlCommand(getSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoadOption", SqlDbType.Int).Value = LoadOption;
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = ObjItem.PostID;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = ObjItem.IsActive;
                dt = DataManager.ExecuteQuerySqlCommand(cmd);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostInformation listItem = new PostInformation();
                        if (LoadOption == LoadPostInformation) // 1
                        {
                            listItem.PostID = dt.Rows[i]["PostID"].ToString();
                            listItem.PostHead = dt.Rows[i]["PostHead"].ToString(); 
                            listItem.PostImage = dt.Rows[i]["PostImage"].ToString();
                            listItem.PostImageBase64Bytes = GetPostImage(dt.Rows[i]["PostID"].ToString(), dt.Rows[i]["PostImage"].ToString());
                            listItem.IsActive = dt.Rows[i]["IsActive"].ToString();
                            listItem.Status = dt.Rows[i]["Status"].ToString();
                            listItem.PostCreatedBy = dt.Rows[i]["PostCreatedBy"].ToString();
                            listItem.PostCreatedUserName = dt.Rows[i]["PostCreatedUserName"].ToString();
                            listItem.PostCreatedDate = dt.Rows[i]["PostCreatedDate"].ToString();
                            listItem.PostUpdatedBy = dt.Rows[i]["PostUpdatedBy"].ToString();
                            listItem.PostUpdatedUserName = dt.Rows[i]["PostUpdatedUserName"].ToString();
                            listItem.PostUpdatedDate = dt.Rows[i]["PostUpdatedDate"].ToString();
                        }
                        if (LoadOption == LoadPostFeedBack) // 1
                        { 
                            listItem.PostID = dt.Rows[i]["PostID"].ToString();
                            listItem.PostHead = dt.Rows[i]["PostHead"].ToString();
                            listItem.PostImage = dt.Rows[i]["PostImage"].ToString();
                            listItem.PostImageBase64Bytes = GetPostImage(dt.Rows[i]["PostID"].ToString(), dt.Rows[i]["PostImage"].ToString());
                            listItem.IsActive = dt.Rows[i]["IsActive"].ToString();
                            listItem.Status = dt.Rows[i]["Status"].ToString();
                            listItem.PostCreatedBy = dt.Rows[i]["PostCreatedBy"].ToString();
                            listItem.PostCreatedUserName = dt.Rows[i]["PostCreatedUserName"].ToString();
                            listItem.PostCreatedDate = dt.Rows[i]["PostCreatedDate"].ToString();
                            listItem.PostUpdatedBy = dt.Rows[i]["PostUpdatedBy"].ToString();
                            listItem.PostUpdatedUserName = dt.Rows[i]["PostUpdatedUserName"].ToString();
                            listItem.PostUpdatedDate = dt.Rows[i]["PostUpdatedDate"].ToString();
                            listItem.PostFeedbackID = dt.Rows[i]["PostFeedbackID"].ToString();
                            listItem.PostComment = dt.Rows[i]["PostComment"].ToString();
                            listItem.PostLike = dt.Rows[i]["PostLike"].ToString();
                            listItem.PostDislike = dt.Rows[i]["PostDislike"].ToString();
                            listItem.PostFeedbackCreatedBy = dt.Rows[i]["PostFeedbackCreatedBy"].ToString();
                            listItem.PostFeedbackCreatedUserName = dt.Rows[i]["PostFeedbackCreatedUserName"].ToString();
                            listItem.PostFeedbackCreatedDate = dt.Rows[i]["PostFeedbackCreatedDate"].ToString();
                            listItem.PostFeedbackUpdatedBy = dt.Rows[i]["PostFeedbackUpdatedBy"].ToString();
                            listItem.PostFeedbackUpdatedUserName = dt.Rows[i]["PostFeedbackUpdatedUserName"].ToString();
                            listItem.PostFeedbackUpdatedDate = dt.Rows[i]["PostFeedbackUpdatedDate"].ToString();                            
                        }
                        listData.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
            }
            finally
            {
                objResult.IsLogin = "0";
            }
            return listData;
        }
        public string GetPostImage(string PostID, string PostImage)
        {
            string base64String = "";
            try
            {
                string _imgname = Guid.NewGuid().ToString();
                var _comPath = "E:/Uploads/PostImage/" + PostID + "_" + PostImage;
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(_comPath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        base64String = Convert.ToBase64String(imageBytes);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return base64String;
        }
        public List<PostInformation> GetPostInformation(string PostID, string IsActive, string User) // 1
        {
            List<PostInformation> listData = new List<PostInformation>();
            PostInformation ObjItem = new PostInformation();

            if (PostID == "" || PostID == null)
            {
                ObjItem.PostID = "-1";
            }
            else
            {
                ObjItem.PostID = PostID;
            }

            if (IsActive == "" || IsActive == null)
            {
                ObjItem.IsActive = "-1";
            }
            else
            {
                ObjItem.IsActive = IsActive;
            }

            listData = GetData(LoadPostInformation, ObjItem, User);
            return listData;
        }
        public List<PostInformation> GetPostFeedBack(string PostID, string IsActive, string User) // 1
        {
            List<PostInformation> listData = new List<PostInformation>();
            PostInformation ObjItem = new PostInformation();

            if (PostID == "" || PostID == null)
            {
                ObjItem.PostID = "-1";
            }
            else
            {
                ObjItem.PostID = PostID;
            }

            if (IsActive == "" || IsActive == null)
            {
                ObjItem.IsActive = "-1";
            }
            else
            {
                ObjItem.IsActive = IsActive;
            }

            listData = GetData(LoadPostFeedBack, ObjItem, User);
            return listData;
        }
        public List<PostInformation> GetPostFeedBack_API() // 1
        {
            List<PostInformation> listData = new List<PostInformation>();
            try
            {
                cmd = new SqlCommand(getSP, DataManager.cnConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoadOption", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = "-1";
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = "-1";
                dt = DataManager.ExecuteQuerySqlCommand(cmd);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostInformation listItem = new PostInformation();
                        listItem.PostID = dt.Rows[i]["PostID"].ToString();
                        listItem.PostHead = dt.Rows[i]["PostHead"].ToString();
                        listItem.PostImage = dt.Rows[i]["PostImage"].ToString();
                        listItem.PostImageBase64Bytes = GetPostImage(dt.Rows[i]["PostID"].ToString(), dt.Rows[i]["PostImage"].ToString());
                        listItem.IsActive = dt.Rows[i]["IsActive"].ToString();
                        listItem.Status = dt.Rows[i]["Status"].ToString();
                        listItem.PostCreatedBy = dt.Rows[i]["PostCreatedBy"].ToString();
                        listItem.PostCreatedUserName = dt.Rows[i]["PostCreatedUserName"].ToString();
                        listItem.PostCreatedDate = dt.Rows[i]["PostCreatedDate"].ToString();
                        listItem.PostUpdatedBy = dt.Rows[i]["PostUpdatedBy"].ToString();
                        listItem.PostUpdatedUserName = dt.Rows[i]["PostUpdatedUserName"].ToString();
                        listItem.PostUpdatedDate = dt.Rows[i]["PostUpdatedDate"].ToString();
                        listItem.PostFeedbackID = dt.Rows[i]["PostFeedbackID"].ToString();
                        listItem.PostComment = dt.Rows[i]["PostComment"].ToString();
                        listItem.PostLike = dt.Rows[i]["PostLike"].ToString();
                        listItem.PostDislike = dt.Rows[i]["PostDislike"].ToString();
                        listItem.PostFeedbackCreatedBy = dt.Rows[i]["PostFeedbackCreatedBy"].ToString();
                        listItem.PostFeedbackCreatedUserName = dt.Rows[i]["PostFeedbackCreatedUserName"].ToString();
                        listItem.PostFeedbackCreatedDate = dt.Rows[i]["PostFeedbackCreatedDate"].ToString();
                        listItem.PostFeedbackUpdatedBy = dt.Rows[i]["PostFeedbackUpdatedBy"].ToString();
                        listItem.PostFeedbackUpdatedUserName = dt.Rows[i]["PostFeedbackUpdatedUserName"].ToString();
                        listItem.PostFeedbackUpdatedDate = dt.Rows[i]["PostFeedbackUpdatedDate"].ToString();
                        listData.Add(listItem);
                    }
                }
            }
            catch (Exception ex)
            {
                objResult.ExceptionError = ex.ToString();
            }
            finally
            {
                objResult.IsLogin = "0";
            }
            return listData; 
        }
        #endregion
    }
}