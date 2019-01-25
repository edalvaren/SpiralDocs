using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiralDocs.Models
{
    public class DocumentLibrary
    {
        public SpiralDoc SpiralDoc{ get; set; }
        
        public enum Categories
        {
            TripReports, 
            DesignGuidelines, 
            Controls,
            InternalDocs
        }

        public enum Topics
        {
            Servo,
            ServoDrive,
            DirectDrive, 
            StructureSupported, 
            Stacker,
            Gen2,
            Gen2Freezer,
            RnD,
            LoadCell,
            TCP,
            SideDrive,
            TwoDrumsOneBelt,
            BiDirectional
        }
    }
}
