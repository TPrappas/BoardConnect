using BoardConnectAPI.APIArgs;
using BoardConnectAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoardConnectAPI.Controllers
{
    public class TaskController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly dbContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Tasks
        /// </summary>
        protected IQueryable<TaskEntity> TasksQuery => mContext.Tasks.Include(x => x.Project);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public TaskController(dbContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new task
        /// </summary>
        /// Post api/tasks
        [HttpPost]
        [Route(Routes.TasksRoute)]
        public Task<ActionResult<TaskResponseModel>> CreateTaskAsync([FromBody] TaskRequestModel model)
            => ControllersHelper.PostAsync<TaskEntity, TaskResponseModel>(
                mContext,
                mContext.Tasks,
                TaskEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the tasks from the database
        /// </summary>
        /// Get api/tasks
        [HttpGet]
        [Route(Routes.TasksRoute)]
        public Task<ActionResult<IEnumerable<TaskResponseModel>>> GetTasksAsync([FromQuery] TaskArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<TaskEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Title.Contains(args.Search));

            // If the Status Type is not null...
            if (args.StatusType is not null)
                // Add to filters
                filters.Add(x => args.StatusType == x.Status);

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

            // If the included Projects is not null...
            if (args.IncludedProjects is not null)
                // Add to filters
                filters.Add(x => args.IncludedProjects.Contains(x.ProjectId));

            // If the excluded Projects is not null...
            if (args.ExcludedProjects is not null)
                // Add to filters
                filters.Add(x => !args.ExcludedProjects.Contains(x.ProjectId));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // Gets the response models for each task entity
            return ControllersHelper.GetAllAsync<TaskEntity, TaskResponseModel>(
                TasksQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the task with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="taskId">The task's id</param>
        /// Get api/tasks/{taskId} == api/tasks/1
        [HttpGet]
        [Route(Routes.TaskRoute)]
        public Task<ActionResult<TaskResponseModel>> GetTaskAsync([FromRoute] int taskId)
        {
            // The needed expression for the filter
            Expression<Func<TaskEntity, bool>> filter = x => x.Id == taskId;

            // Gets the response model 
            return ControllersHelper.GetAsync<TaskEntity, TaskResponseModel>(
                TasksQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the task with the specified id
        /// </summary>
        /// <param name="taskId">The task's id</param>
        /// <param name="model">The task request model</param>
        /// Put /api/tasks/{taskId}
        [HttpPut]
        [Route(Routes.TaskRoute)]
        public Task<ActionResult<TaskResponseModel>> UpdateProjectAsync([FromRoute] int taskId, [FromBody] TaskRequestModel model)
        {
            return ControllersHelper.PutAsync<TaskRequestModel, TaskEntity, TaskResponseModel>(
                mContext,
                TasksQuery,
                model,
                x => x.Id == taskId);
        }

        /// <summary>
        /// Deletes the task with the specified id if exists from the database
        /// </summary>
        /// <param name="taskId">The task's id</param>
        /// Delete /api/tasks/{taskId}
        [HttpDelete]
        [Route(Routes.TaskRoute)]
        public Task<ActionResult<TaskResponseModel>> DeleteProjectAsync([FromRoute] int taskId)
        {
            return ControllersHelper.DeleteAsync<TaskEntity, TaskResponseModel>(
                mContext,
                TasksQuery,
                DI.GetMapper,
                x => x.Id == taskId);
        }

        #endregion
    }
}
