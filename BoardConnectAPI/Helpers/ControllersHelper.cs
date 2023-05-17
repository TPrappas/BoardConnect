using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoardConnectAPI.Helpers
{
    public class ControllersHelper
    {
        #region Public Methods

        /// <summary>
        /// Post request
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="dBContext"></param>
        /// <param name="dbSet"></param>
        /// <param name="entity"></param>
        /// <param name="projector">Creates a <typeparamref name="TResponseModel"/> from the inserted <typeparamref name="TEntity"/></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> PostAsync<TEntity, TResponseModel>(dbContext dBContext, DbSet<TEntity> dbSet, TEntity entity, Func<TEntity, TResponseModel> projector)
           where TEntity : class
        {
            // Add it to the database
            dbSet.Add(entity);

            // Save the changes in the database
            await dBContext.SaveChangesAsync();

            // Create a response model from the entity
            var responseModel = projector(entity);

            // Returns the response model
            return responseModel;
        }

        /// <summary>
        /// Gets all the response models
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="query">The db set</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<ActionResult<IEnumerable<TResponseModel>>> GetAllAsync<TEntity, TResponseModel>(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> filter)
            where TEntity : BaseEntity
        {
            // Gets the all the entities of the db set 
            var entities = await query.Where(filter).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the response models of the entities
            return new OkObjectResult(DI.GetMapper.Map<IEnumerable<TResponseModel>>(entities));
        }

        /// <summary>
        /// Gets all the response models
        /// </summary>
        /// <typeparam name="TEntity">The entity</typeparam>
        /// <typeparam name="TResponseModel">The response model</typeparam>
        /// <param name="query">The db set</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<ActionResult<IEnumerable<TResponseModel>>> GetAllAsync<TEntity, TResponseModel>(IQueryable<TEntity> query, BaseArgs args, List<Expression<Func<TEntity, bool>>> filters)
            where TEntity : BaseEntity
        {
            foreach (var filter in filters)
                query = query.Where(filter);

            // Gets the all the entities of the db set 
            var entities = await query.Skip(args.Page * args.PerPage).Take(args.PerPage).ToListAsync();

            // Creates and returns an Microsoft.AspNetCore.Mvc.OkObjectResult object that
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK
            // response with all the response models of the entities
            return new OkObjectResult(DI.GetMapper.Map<IEnumerable<TResponseModel>>(entities));
        }

        /// <summary>
        /// Gets response model based on id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TResponseModel"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="mapper"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> GetAsync<TEntity, TResponseModel>(IQueryable<TEntity> dbSet, IMapper mapper, Expression<Func<TEntity, bool>> filter)
            where TEntity : BaseEntity
        {
            // If exists finds the entity
            var entity = await dbSet.FirstOrDefaultAsync(filter, cancellationToken: default);

            // If the entity does not exist...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Return the response model of the entity
            return mapper.Map<TResponseModel>(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <typeparam name="TRequestModel"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TResponseModel"></typeparam>
        /// <param name="dBContext"></param>
        /// <param name="dbSet"></param>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> PutAsync<TRequestModel, TEntity, TResponseModel>(dbContext dBContext, IQueryable<TEntity> dbSet, TRequestModel model, Expression<Func<TEntity, bool>> expression)
        where TEntity : BaseEntity
        {
            // Gets the entity if exists
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            // If no entity is found...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Copy the non-null values from the request model to the entity
            DI.GetMapper.Map(model, entity);

            // Saves the changes in the database
            await dBContext.SaveChangesAsync();

            // Maps the entity to a response model and returns it
            return DI.GetMapper.Map<TEntity, TResponseModel>(entity);
        }

        /// <summary>
        /// Deletes
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TResponseModel"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="queryable"></param>
        /// <param name="mapper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static async Task<ActionResult<TResponseModel>> DeleteAsync<TEntity, TResponseModel>(DbContext dbContext, IQueryable<TEntity> queryable, IMapper mapper, Expression<Func<TEntity, bool>> expression)
            where TEntity : BaseEntity
        {
            // Gets the entity if exists
            var entity = await queryable.FirstOrDefaultAsync(expression);

            // If no entity is found...
            if (entity == null)
                // Return not found
                return new NotFoundResult();

            // Removes the entity from the db set
            dbContext.Remove(entity);

            // Saves the changes to the data base
            await dbContext.SaveChangesAsync();

            // Returns the response model of the entity that was removed
            return mapper.Map<TResponseModel>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TRequestModel"></typeparam>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TEntity FromRequestModel<TEntity, TRequestModel>(TRequestModel model, Action<TEntity> action = null)
            where TEntity : BaseEntity
        {
            // Maps the request model to the entity
            var entity = DI.GetMapper.Map<TEntity>(model);
            if (action != null)
            {
                // Calls the action
                action.Invoke(entity);
            }

            // Returns the entity
            return entity;
        }

        public static TResponseModel ToResponseModel<TEntity, TResponseModel>(TEntity entity)
            where TResponseModel : BaseResponseModel => DI.GetMapper.Map<TResponseModel>(entity);

        #endregion

    }
}
