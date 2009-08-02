﻿//-----------------------------------------------------------------------
// <copyright file="EtsyContext.cs" company="AFS">
// Copyright (c) AFS. All rights reserved.
// </copyright>
//----------------------------------------------------------------------- 
namespace Netsy.DataModel
{
    /// <summary>
    /// Context data for etsy services
    /// </summary>
    public class EtsyContext
    {
        /// <summary>
        /// The defaultUrl to use for all Etsy API access
        /// </summary>
        private const string DefaultBaseUrl = "http://beta-api.etsy.com/v1/";

        /// <summary>
        /// Creates a new instance of the Etsy context with a base URl and APi key
        /// </summary>
        /// <param name="baseUrl">the base Url to use</param>
        /// <param name="apiKey">the API key to use</param>
        public EtsyContext(string baseUrl, string apiKey)
        {
            this.BaseUrl = baseUrl;
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Creates a new instance of the Etsy context with a base URl and APi key
        /// </summary>
        /// <param name="apiKey">the API key to use</param>
        public EtsyContext(string apiKey)
        {
            this.BaseUrl = DefaultBaseUrl;
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Gets the Url prefix for the Etsy API
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Gets the Applicaiton's Etsy API Key
        /// </summary>
        public string ApiKey { get; private set; }
    }
}
