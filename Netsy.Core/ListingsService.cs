﻿//-----------------------------------------------------------------------
// <copyright file="ListingsService.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Core
{
    using System;
    using System.Collections.Generic;

    using Netsy.DataModel;
    using Netsy.DataModel.ListingData;
    using Netsy.Helpers;
    using Netsy.Interfaces;

    /// <summary>
    /// Implementation of the listings service
    /// </summary>
    public class ListingsService : IListingService   
    {
        /// <summary>
        /// the Etsy context data
        /// </summary>
        private readonly EtsyContext etsyContext;

        /// <summary>
        /// Initializes a new instance of the ListingsService class
        /// </summary>
        /// <param name="etsyContext">the etsy context to use</param>
        public ListingsService(EtsyContext etsyContext)
        {
            this.etsyContext = etsyContext;
        }

        #region IListingService Members

        /// <summary>
        /// GetListingDetails completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingDetailsCompleted;

        /// <summary>
        /// GetAllListingscompleted event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetAllListingsCompleted;

        /// <summary>
        /// GetListingsByCategory completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByCategoryCompleted;

        /// <summary>
        /// GetListingsByColor completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByColorCompleted;

        /// <summary>
        /// GetListingsByColorAndKeywords completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByColorAndKeywordsCompleted;

        /// <summary>
        /// GetFrontFeaturedListings completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetFrontFeaturedListingsCompleted;

        /// <summary>
        /// GetListingsByKeyword completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByKeywordCompleted;

        /// <summary>
        /// GetListingsByMaterials completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByMaterialsCompleted;

        /// <summary>
        /// GetListingsByTags completed event
        /// </summary>
        public event EventHandler<ResultEventArgs<Listings>> GetListingsByTagsCompleted;

        /// <summary>
        /// Get the details of a listing.
        /// </summary>
        /// <param name="listingId">Specify the listing's numeric ID</param>
        /// <param name="detailLevel">Control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingDetails(int listingId, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingDetailsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings", listingId)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingDetailsCompleted);
        }

        /// <summary>
        /// Get all active listings on Etsy.
        /// </summary>
        /// <param name="sortOn">Specify the field to sort on</param>
        /// <param name="sortOrder">Specify the direction to sort on</param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetAllListings(SortField sortOn, SortOrder sortOrder, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetAllListingsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/all")
                .Sort(sortOn, sortOrder)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetAllListingsCompleted);
        }

        /// <summary>
        /// Search for listings by category.
        /// </summary>
        /// <param name="category">the category name</param>
        /// <param name="sortOn">Specify the field to sort on</param>
        /// <param name="sortOrder">Specify the direction to sort on</param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByCategory(string category, SortField sortOn, SortOrder sortOrder, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByCategoryCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/category", category)
                .Sort(sortOn, sortOrder)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel); 
            
            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByCategoryCompleted);
        }

        /// <summary>
        /// Search for listings by average color of primary image.
        /// </summary>
        /// <param name="color">The average color of primary image</param>
        /// <param name="wiggle">Specify the degree of tolerance for color matching; where 0 is the most accurate, and 15 is the leas</param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByColor(EtsyColor color, int wiggle, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByColorCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/color", color)
                .Param("wiggle", wiggle)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByColorCompleted);
        }

        /// <summary>
        /// Search for listings by keywords and average color of primary image.
        /// </summary>
        /// <param name="keywords">Specify keywords to search on, separated by spaces or semicolons. You can also use the operators AND and NOT to control keyword matching.</param>
        /// <param name="color">Specify an HSV color</param>
        /// <param name="wiggle">Specify the degree of tolerance for color matching; where 0 is the most accurate, and 15 is the least.</param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByColorAndKeywords(IEnumerable<string> keywords, EtsyColor color, int wiggle, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByColorAndKeywordsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/color", color)
                .Append("/keywords/").Append(keywords)
                .Param("wiggle", wiggle)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByColorAndKeywordsCompleted);
        }

        /// <summary>
        /// Get the featured listings on the front page for the current day.
        /// </summary>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetFrontFeaturedListings(int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetFrontFeaturedListingsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/featured/front")
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetFrontFeaturedListingsCompleted);
        }

        /// <summary>
        /// Search for listings by keyword.
        /// </summary>
        /// <param name="searchTerms">Specify keywords to search on, separated by spaces or semicolons. You can also use the operators AND and NOT to control keyword matching.</param>
        /// <param name="sortOn">Specify the field to sort on</param>
        /// <param name="sortOrder">Specify the direction to sort on </param>
        /// <param name="minPrince">Minimum for restricting price ranges. Values are in US dollars and may include cents.</param>
        /// <param name="maxPrice">Maximum for restricting price ranges. Values are in US dollars and may include cents.</param>
        /// <param name="searchDescription">If true, listing descriptions will count towards search matches. (This may produce less relevant results.)</param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByKeyword(IEnumerable<string> searchTerms, SortField sortOn, SortOrder sortOrder, decimal? minPrince, decimal? maxPrice, bool searchDescription, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByKeywordCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/keywords")
                .Append(searchTerms)
                .Sort(sortOn, sortOrder)
                .OptionalParam("min_price", minPrince)
                .OptionalParam("max_price", maxPrice)
                .Param("search_description", searchDescription)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByKeywordCompleted);
        }

        /// <summary>
        /// Search for listings by materials used.
        /// </summary>
        /// <param name="materials">Specify one or more materials, separated by spaces or semicolons.</param>
        /// <param name="sortOn">Specify the field to sort on</param>
        /// <param name="sortOrder">Specify the direction to sort on </param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByMaterials(IEnumerable<string> materials, SortField sortOn, SortOrder sortOrder, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByMaterialsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/materials")
                .Append(materials)
                .Sort(sortOn, sortOrder)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel); 
            
            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByMaterialsCompleted);
        }

        /// <summary>
        /// Search for listings by tags.
        /// </summary>
        /// <param name="tags">Specify one or more tags, separated by spaces or semicolons.</param>
        /// <param name="sortOn">Specify the field to sort on</param>
        /// <param name="sortOrder">Specify the direction to sort on </param>
        /// <param name="offset">To page through large result sets</param>
        /// <param name="limit">Specify the number of results to return</param>
        /// <param name="detailLevel">control how much information to return</param>
        /// <returns>the async state of the request</returns>
        public IAsyncResult GetListingsByTags(IEnumerable<string> tags, SortField sortOn, SortOrder sortOrder, int offset, int limit, DetailLevel detailLevel)
        {
            if (!ServiceHelper.TestCallPrerequisites(this, this.GetListingsByTagsCompleted, this.etsyContext))
            {
                return null;
            }

            UriBuilder uriBuilder = UriBuilder.Start(this.etsyContext, "listings/tags")
                .Append(tags)
                .Sort(sortOn, sortOrder)
                .OffsetLimit(offset, limit)
                .DetailLevel(detailLevel);

            return ServiceHelper.GenerateRequest(this, uriBuilder.Result(), this.GetListingsByTagsCompleted);
        }

        #endregion
    }
}
