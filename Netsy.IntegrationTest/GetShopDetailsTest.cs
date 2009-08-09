﻿//-----------------------------------------------------------------------
// <copyright file="GetShopDetailsTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.IntegrationTest
{
    using System.Threading;

    using DataModel.ShopData;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Netsy.Core;
    using Netsy.DataModel;
    using Netsy.Helpers;
    using Netsy.Interfaces;

    /// <summary>
    /// Test etsy shop retrieval
    /// </summary>
    [TestClass]
    public class GetShopDetailsTest
    {
        /// <summary>
        /// Test missing APi key
        /// </summary>
        [TestMethod]
        public void ShopRetrievalMissingApiKeyTest()
        {
            ResultEventArgs<Shops> result = null;
            IShopService shopsService = new ShopService(new EtsyContext(string.Empty));
            shopsService.GetShopDetailsCompleted += (s, e) => result = e;

            // ACT
            shopsService.GetShopDetails(NetsyData.TestUserId, DetailLevel.Low);

            // check the data
            NetsyData.CheckResultFailure(result);
        }

        /// <summary>
        /// Test retrieving etsy shops by id
        /// </summary>
        [TestMethod]
        public void ShopLowDetailRetrievalTest()
        {
            // ARRANGE
            using (AutoResetEvent waitEvent = new AutoResetEvent(false))
            {
                ResultEventArgs<Shops> result = null;
                IShopService shopsService = new ShopService(new EtsyContext(NetsyData.EtsyApiKey));
                shopsService.GetShopDetailsCompleted += (s, e) =>
                {
                    result = e;
                    waitEvent.Set();
                };

                // ACT
                shopsService.GetShopDetails(NetsyData.TestUserId, DetailLevel.Low);
                bool signalled = waitEvent.WaitOne(NetsyData.WaitTimeout);

                // ASSERT
                // check that the event was fired, did not time out
                Assert.IsTrue(signalled, "Not signalled");

                // check the data
                NetsyData.CheckResultSuccess(result);

                Assert.IsNotNull(result.ResultValue.Params);
                Assert.IsNotNull(result.ResultValue.Results);
                Assert.AreEqual(1, result.ResultValue.Count);
            }
        }
    }
}
