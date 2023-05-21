using BoardConnectAPI.Helpers;

namespace BoardConnectAPI
{
    public class TaskEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="Progress"/> property
        /// </summary>
        private uint mProgress = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get => mTitle ?? string.Empty;

            set => mTitle = value;
        }

        /// <summary>
        /// The discription
        /// </summary>
        public string Description
        {
            get => mDescription ?? string.Empty;

            set => mDescription = value;
        }

        /// <summary>
        /// The progress
        /// </summary>
        public uint Progress 
        { 
            get => mProgress; 
            
            set
            {
                mProgress = value;
                if(mProgress > 100) 
                    mProgress = 100;
            }
        }

        /// <summary>
        /// The status
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset FinishDate { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        /// The id of the related company
        public int ProjectId { get; set; }

        /// <summary>
        /// The related <see cref="ProjectEntity"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public ProjectEntity? Project { get; set; }

        #endregion

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="TaskEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TaskEntity FromRequestModel(TaskRequestModel model)
            => ControllersHelper.FromRequestModel<TaskEntity, TaskRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="UserResponseModel"/> from the current <see cref="TaskEntity"/>
        /// </summary>
        /// <returns></returns>
        public TaskResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<TaskEntity, TaskResponseModel>(this);

        #endregion
    }
}
