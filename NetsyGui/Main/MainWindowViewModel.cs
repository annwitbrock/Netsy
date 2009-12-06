﻿//-----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace NetsyGui.Main
{
    using System.Collections.ObjectModel;

    using NetsyGui.ViewModels;

    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Number of items to retrieve
        /// </summary>
        public const int ItemPerPage = 12;
        
        /// <summary>
        /// the listings shown on the gui
        /// </summary>
        private readonly ObservableCollection<ListingViewModel> listings = new ObservableCollection<ListingViewModel>();

        /// <summary>
        /// the page index into the results
        /// </summary>
        private int pageNumber = 1;

        /// <summary>
        /// The text to display on the status bar
        /// </summary>
        private string statusText;

        /// <summary>
        /// Keywords for listings
        /// </summary>
        private string listingKeywords;

        /// <summary>
        /// color for listings
        /// </summary>
        private string colourText;

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class
        /// </summary>
        public MainWindowViewModel()
        {
            this.StatusText = "Etsy Gui";
            CommandLocator.MainWindowLoadFrontFeaturedListingsCommand.Execute(this);
        }

        /// <summary>
        /// Gets the Listings 
        /// </summary>
        public ObservableCollection<ListingViewModel> Listings
        {
            get { return this.listings; }
        }

        /// <summary>
        /// Gets or sets the page index into the results
        /// </summary>
        public int PageNumber
        {
            get
            {
                return this.pageNumber;
            }

            set
            {
                if (this.pageNumber != value)
                {
                    this.pageNumber = value;
                    this.OnPropertyChanged("PageNumber");
                }
            }
        }

        /// <summary>
        /// Gets or sets the status bar text
        /// </summary>
        public string StatusText
        {
            get
            {
                return this.statusText;
            }

            set
            {
                if (this.statusText != value)
                {
                    this.statusText = value;
                    this.OnPropertyChanged("StatusText");
                }
            }
        }

        /// <summary>
        /// Gets or sets the listing keywords
        /// </summary>
        public string ListingKeywords
        {
            get
            {
                return this.listingKeywords;
            }

            set
            {
                if (this.listingKeywords != value)
                {
                    this.listingKeywords = value;
                    this.OnPropertyChanged("ListingKeywords");
                }
            }
        }

        /// <summary>
        /// Gets or sets the color for listings
        /// </summary>
        public string ColorText
        {
            get
            {
                return this.colourText;
            }

            set
            {
                if (this.colourText != value)
                {
                    this.colourText = value;
                    this.OnPropertyChanged("ColorText");
                }
            }
        }
    }
}
