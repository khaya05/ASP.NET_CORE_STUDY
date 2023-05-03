﻿using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraints;

public class MonthsCustomConstraints : IRouteConstraint
{
  public bool Match(
    HttpContext? httpContext, 
    IRouter? route, 
    string routeKey, 
    RouteValueDictionary values, 
    RouteDirection routeDirection
    )
  {
    // check whether walues exists
    if(!values.ContainsKey(routeKey)) return false;

    Regex regex = new Regex("^(apr|jul|oct|jan)$");
    string? monthValue = Convert.ToString(values[routeKey]);

    if(regex.IsMatch(monthValue)) return true;
    return false;

  }
}
