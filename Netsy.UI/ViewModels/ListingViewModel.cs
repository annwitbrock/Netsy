﻿//-----------------------------------------------------------------------
// <copyright file="ListingViewModel.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 
namespace Netsy.UI.ViewModels
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;

    using Netsy.DataModel;

    /// <summary>
    /// View model for a listing
    /// </summary>
    public class ListingViewModel : BaseViewModel
    {
        /// <summary>
        /// the listing data transfer object
        /// </summary>
        private readonly Listing listing;

        /// <summary>
        /// The currency cymbol, e.g. "$" or "£"
        /// </summary>
        private readonly string currencySymbol = string.Empty;

        /// <summary>
        /// the visibility of the link to show the shop
        /// </summary>
        private Visibility shopLinkVisibility = Visibility.Visible;

        /// <summary>
        /// the visibility of the link to show the listing
        /// </summary>
        private Visibility listingLinkVisibility = Visibility.Visible;

        /// <summary>
        /// Command to show the shop in a seperate display
        /// </summary>
        private ICommand showShopCommand;

        /// <summary>
        /// Command to show the listing in a seperate display
        /// </summary>
        private ICommand showListingCommand;

        /// <summary>
        /// Initializes a new instance of the ListingViewModel class
        /// </summary>
        /// <param name="listing">the listing Data transfer object</param>
        public ListingViewModel(Listing listing)
        {
            this.listing = listing;

            if (!string.IsNullOrEmpty(listing.CurrencyCode))
            {
                this.currencySymbol = CurrencySymbolLookup.CurrencySymbolFromCurrencyCode(listing.CurrencyCode);
            }
        }

        /// <summary>
        /// Gets the Listing data transfer object
        /// </summary>
        public Listing Listing
        {
            get { return this.listing; }
        }

        /// <summary>
        /// Gets or sets the visibility of the link to the shop
        /// </summary>
        public Visibility ShopLinkVisibility
        {
            get
            {
                return this.shopLinkVisibility;
            }

            set
            {
                if (this.shopLinkVisibility != value)
                {
                    this.shopLinkVisibility = value;
                    this.OnPropertyChanged("ShopLinkVisibility");
                }
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the link to show the listing
        /// </summary>
        public Visibility ListingLinkVisibility
        {
            get
            {
                return this.listingLinkVisibility;
            }

            set
            {
                if (this.listingLinkVisibility != value)
                {
                    this.listingLinkVisibility = value;
                    this.OnPropertyChanged("ListingLinkVisibility");
                }
            }
        }

        /// <summary>
        /// Gets the price display data 
        /// </summary>
        public string PriceData
        {
            get
            {
                return this.currencySymbol + 
                    string.Format(CultureInfo.InvariantCulture, "{0:0.00}", this.Listing.Price) + 
                    " " + 
                    this.Listing.CurrencyCode;
            }
        }

        /// <summary>
        /// Gets date data for display
        /// </summary>
        public string DateDisplay
        {
            get
            {
                if (this.Listing.CreationDate.HasValue)
                {
                    string result = this.Listing.CreationDate.Value.ToShortDateString();
                    if (this.Listing.EndingDate.HasValue)
                    {
                        result += " to " + this.Listing.EndingDate.Value.ToShortDateString();
                    }

                    return result;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the command to show the shop in a seperate display
        /// </summary>
        public ICommand ShowShopCommand
        {
            get
            {
                return this.showShopCommand;
            }

            set
            {
                this.showShopCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the command to show the listing in a seperate display
        /// </summary>
        public ICommand ShowListingCommand
        {
            get
            {
                return this.showListingCommand;
            }

            set
            {
                this.showListingCommand = value;
            }
        }
    }
}
