using BoardConnectAPI.Helpers;

namespace BoardConnectAPI
{
    public class ProjectEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The discription
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The progress
        /// </summary>
        public decimal Progress { get; set; }

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
        public ICollection<TaskEntity> Tasks { get; set; }

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
