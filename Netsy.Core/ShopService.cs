﻿//-----------------------------------------------------------------------
// <copyright file="UsersService.cs" company="AFS">
// Copyright (c) AFS. All rights reserved.
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Core
{
    using System;

    using Netsy.DataModel;
    using Netsy.DataModel.ShopData;
    using Netsy.Helpers;
    using Netsy.Interfaces;

    /// <summary>
    /// Implementation of th shop service
    /// </summary>
    public class ShopService : IShopService
    {
        /// <summary>
        /// the API to use for authentication
        /// </summary>
        private readonly string ApiKey;

        /// <summary>
        /// Initializes a new instance of the UsersService class
        /// </summary>
        /// <param name="apiKey">the API key to use</param>
        public ShopService(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        #region IShopService Members

        public event EventHandler<ResultEventArgs<Shops>> GetShopDetailsCompleted;

        public event EventHandler<ResultEventArgs<Shops>> GetShopsByNameCompleted;

        public IAsyncResult GetShopDetails(int userId, DetailLevel detailLevel)
        {
            if (string.IsNullOrEmpty(this.ApiKey))
            {
                ResultEventArgs<Shops> errorResult = new ResultEventArgs<Shops>(null, new ResultStatus("No Api key", null));
                ServiceHelper.TestSendEvent(this.GetShopDetailsCompleted, this, errorResult);
                return null;
            }

            string url = Constants.BaseUrl + "shops/" + userId +
                "?api_key=" + this.ApiKey +
                "&detail_level=" + detailLevel.ToStringLower();

            return ServiceHelper.GenerateRequest(new Uri(url),
                s =>
                {
                    Shops shops = s.Deserialize<Shops>();
                    ResultEventArgs<Shops> sucessResult = new ResultEventArgs<Shops>(shops, new ResultStatus(true));
                    ServiceHelper.TestSendEvent(this.GetShopDetailsCompleted, this, sucessResult);
                });
        }

        public IAsyncResult GetShopsByName(string searchName, SortOrder sortOrder, int offset, int limit, DetailLevel detailLevel)
        {
            if (string.IsNullOrEmpty(this.ApiKey))
            {
                ResultEventArgs<Shops> errorResult = new ResultEventArgs<Shops>(null, new ResultStatus("No Api key", null));
                ServiceHelper.TestSendEvent(this.GetShopsByNameCompleted, this, errorResult);
                return null;
            }

            string url = Constants.BaseUrl + "shops/keywords/" + searchName +
                "?api_key=" + this.ApiKey +
                "&sort_order=" + sortOrder.ToStringLower() +
                "&offset=" + offset +
                "&limit=" + limit +
                "&detail_level=" + detailLevel.ToStringLower();

            return ServiceHelper.GenerateRequest(new Uri(url),
                s =>
                {
                    Shops shops = s.Deserialize<Shops>();
                    ResultEventArgs<Shops> sucessResult = new ResultEventArgs<Shops>(shops, new ResultStatus(true));
                    ServiceHelper.TestSendEvent(this.GetShopsByNameCompleted, this, sucessResult);
                });
        }

        #endregion
    }
}