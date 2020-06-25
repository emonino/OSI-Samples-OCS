﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Appium.Interfaces.Generic.SearchContext;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;

namespace OCSConnectorTest
{
    public static class Extensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catch intended for retry logic")]
        public static T TryFindElementByName<T>(this IGenericFindsByName<T> element, string name, int seconds = 30) where T : IWebElement
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed < TimeSpan.FromSeconds(seconds))
            {
                try
                {
                    var result = element.FindElementByName(name);
                    if (result != null) return result;
                }
                catch { }
            }

            return default;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catch intended for retry logic")]
        public static T TryFindElementByAccessibilityId<T>(this IFindByAccessibilityId<T> element, string name, int seconds = 30) where T : IWebElement
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed < TimeSpan.FromSeconds(seconds))
            {
                try
                {
                    var result = element.FindElementByAccessibilityId(name);
                    if (result != null) return result;
                }
                catch { }
            }

            return default;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catch intended for retry logic")]
        public static ReadOnlyCollection<T> TryFindElementsByName<T>(this IGenericFindsByName<T> element, string name, int seconds = 30) where T : IWebElement
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            Stopwatch sw = Stopwatch.StartNew();
            while (sw.Elapsed < TimeSpan.FromSeconds(seconds))
            {
                try
                {
                    var result = element.FindElementsByName(name);
                    if (result != null && result.Count > 0) return result;
                }
                catch { }
            }

            return null;
        }
    }
}