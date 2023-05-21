using BoardConnectAPI.Helpers;
using System.Collections.ObjectModel;

namespace BoardConnectAPI
{
    public class ProjectEntity : BaseEntity
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
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Tasks"/> property
        /// </summary>
        private ICollection<TaskEntity>? mTasks;

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
        /// The name
        /// </summary>
        public string Name
        { 
            get => mName ?? string.Empty;
            
            set => mName = value;
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
                if (mProgress > 100)
                    mProgress = 100;
            }
        }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset FinishDate { get; set;}

        #region RelationShips

        /// <summary>
        /// The tasks
        /// </summary>
        public ICollection<TaskEntity> Tasks 
        { 
            get => mTasks ??= new Collection<TaskEntity>();
            
            set => mTasks = value;
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ProjectEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProjectEntity FromRequestModel(ProjectRequestModel model)
            => ControllersHelper.FromRequestModel<ProjectEntity, ProjectRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="ProjectResponseModel"/> from the current <see cref="ProjectEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProjectResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<ProjectEntity, ProjectResponseModel>(this);

        #endregion
    }
}
