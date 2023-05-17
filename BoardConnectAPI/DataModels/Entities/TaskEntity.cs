﻿using BoardConnectAPI.Helpers;

namespace BoardConnectAPI
{
    public class TaskEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The progress
        /// </summary>
        public decimal Progress { get; set; }

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
        public ProjectEntity Project { get; set; }

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