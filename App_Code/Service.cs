using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Web.Services;
using System.Configuration;
using Subgurim;
using Subgurim.Controles;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    
    public Service()
    {
       
        BasicHttpBinding httpBinding = new BasicHttpBinding();
        httpBinding.MaxReceivedMessageSize = 2147483647;
        httpBinding.MaxBufferSize = 2147483647;
    }

    public GLatLng getDirection(string latitude, string logitude)
    {
        GLatLng latLng = null;
        //string output;
        if (latitude.Length != 0 && logitude.Length != 0) 
        {

            using (WebClient client = new WebClient())
            {
                latLng = new GLatLng(Convert.ToDouble(latitude), Convert.ToDouble(logitude));
                return (latLng);
            }

        }
        else
        {
            return (latLng);
        }

        
    }

    public GInfoWindow getMarker(string latitude, string logitude, string label)
    {
        GLatLng latLng = null;
        GInfoWindowOptions windowOptions;
        GInfoWindow commonInfoWindow = null;
        //string output;
        if (latitude.Length != 0 && logitude.Length != 0)
        {
            latLng = getDirection((latitude), (logitude));
            GMarker marker = new GMarker(latLng);
            windowOptions = new GInfoWindowOptions();
            commonInfoWindow = new GInfoWindow(marker, label, windowOptions);
            return (commonInfoWindow);
        }
        else
        {
            return (commonInfoWindow);
        }


    }
    public GDirection getLetGO(string button_name, string start, string end, string div_direction)
    {
        GDirection direction = new GDirection();
        direction.autoGenerate = false;
        direction.buttonElementId = button_name;
        direction.fromElementId = start;
        direction.toElementId = end;
        direction.divElementId = div_direction;
        direction.clearMap = true;

        //direction.avoidHighways = true;
        //direction.travelMode = GDirection.GTravelModeEnum.G_TRAVEL_MODE_WALKING;
        //direction.locale = "en";

        return(direction);

    }


}
