using BoardConnectAPI.APIArgs;
using BoardConnectAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoardConnectAPI
{
    public class ProjectController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly dbContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Projects
        /// </summary>
        protected IQueryable<ProjectEntity> ProjectsQuery => mContext.Projects.Include(x => x.Tasks);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProjectController(dbContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// Post api/projects
        [HttpPost]
        [Route(Routes.ProjectsRoute)]
        public Task<ActionResult<ProjectResponseModel>> CreateProjectAsync([FromBody] ProjectRequestModel model)
            => ControllersHelper.PostAsync<ProjectEntity, ProjectResponseModel>(
                mContext,
                mContext.Projects,
                ProjectEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the projects from the database
        /// </summary>
        /// Get api/projects
        [HttpGet]
        [Route(Routes.ProjectsRoute)]
        public Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetProjectsAsync([FromQuery] ProjectArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<ProjectEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Title.Contains(args.Search));

            // If Name is not null...
            if (!string.IsNullOrEmpty(args.Name))
                // Add to filters
                filters.Add(x => x.Name.Contains(args.Name));

            // If the Min Progress is not null...
            if (args.MinProgress != null)
                // Add to filters
                filters.Add(x => args.MinProgress >= x.Progress);

            // If the Max Progress is not null...
            if (args.MaxProgress != null)
                // Add to filters
                filters.Add(x => args.MaxProgress <= x.Progress);

            // If the After Start Date is not null...
            if (args.AfterStartDate is not null)
                // Add to filters
                filters.Add(x => x.StartDate >= args.AfterStartDate);

            // If the Before Start Date is not null...
            if (args.BeforeStartDate is not null)
                // Add to filters
                filters.Add(x => x.StartDate <= args.BeforeStartDate);

            // If the After Finish Date is not null...
            if (args.AfterFinishDate is not null)
                // Add to filters
                filters.Add(x => x.FinishDate >= args.AfterFinishDate);

            // If the Before Finish Date is not null...
            if (args.BeforeFinishDate is not null)
                // Add to filters
                filters.Add(x => x.FinishDate <= args.BeforeFinishDate);

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // Gets the response models for each project entity
            return ControllersHelper.GetAllAsync<ProjectEntity, ProjectResponseModel>(
                ProjectsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the project with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// Get api/projects/{projectId} == api/projects/1
        [HttpGet]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> GetProjectAsync([FromRoute] int projectId)
        {
            // The needed expression for the filter
            Expression<Func<ProjectEntity, bool>> filter = x => x.Id == projectId;

            // Gets the response model 
            return ControllersHelper.GetAsync<ProjectEntity, ProjectResponseModel>(
                ProjectsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Gets the project with the specified id and the tasks from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// Get api/projects/{projectId}/tasks == api/projects/1/tasks
        [HttpGet]
        [Route(Routes.ProjectTasksRoute)]
        public Task<ActionResult<EmbeddedProjectResponseModel>> GetProjectTasksAsync([FromRoute] int projectId)
        {
            // The needed expression for the filter
            Expression<Func<ProjectEntity, bool>> filter = x => x.Id == projectId;

            // Gets the response model 
            return ControllersHelper.GetAsync<ProjectEntity, EmbeddedProjectResponseModel>(
                ProjectsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the project with the specified id
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// <param name="model">The project request model</param>
        /// Put /api/projects/{projectId}
        [HttpPut]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> UpdateProjectAsync([FromRoute] int projectId, [FromBody] ProjectRequestModel model)
        {
            return ControllersHelper.PutAsync<ProjectRequestModel, ProjectEntity, ProjectResponseModel>(
                mContext,
                ProjectsQuery,
                model,
                x => x.Id == projectId);
        }

        /// <summary>
        /// Deletes the project with the specified id if exists from the database
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// Delete /api/projects/{projectId}
        [HttpDelete]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> DeleteProjectAsync([FromRoute] int projectId)
        {
            return ControllersHelper.DeleteAsync<ProjectEntity, ProjectResponseModel>(
                mContext,
                ProjectsQuery,
                DI.GetMapper,
                x => x.Id == projectId);
        }

        #endregion
    }
}
