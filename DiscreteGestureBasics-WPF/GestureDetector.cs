//------------------------------------------------------------------------------
// <copyright file="GestureDetector.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Kinect;
    using Microsoft.Kinect.VisualGestureBuilder;

    /// <summary>
    /// Gesture Detector class which listens for VisualGestureBuilderFrame events from the service
    /// and updates the associated GestureResultView object with the latest results for the 'Seated' gesture
    /// </summary>
    public class GestureDetector : IDisposable
    {

        VideoPlayer w1;
        /// <summary> Path to the gesture database that was trained with VGB </summary>
        private string gestureDatabase;

        private static test tmp = new test();
        private readonly string[] Gandalf = { "GandalfP1", "GandalfP2", "GandalfP3", "GandalfP4" };
        private Boolean[] GandalfPr = { false, false, false, false };

        private readonly string[] Goku = { "GokuP1", "GokuP2" };
        private Boolean[] GokuPr = { false, false };

        private string videoPath = null;
        /// <summary> Gesture frame source which should be tied to a body tracking ID </summary>
        private VisualGestureBuilderFrameSource vgbFrameSource = null;

        /// <summary> Gesture frame reader which will handle gesture events coming from the sensor </summary>
        private VisualGestureBuilderFrameReader vgbFrameReader = null;

        /// <summary>
        /// Initializes a new instance of the GestureDetector class along with the gesture frame source and reader
        /// </summary>
        /// <param name="kinectSensor">Active sensor to initialize the VisualGestureBuilderFrameSource object with</param>
        /// <param name="gestureResultView">GestureResultView object to store gesture results of a single body to</param>
        public GestureDetector(KinectSensor kinectSensor, GestureResultView gestureResultView, String databasePath, String videoPath)
        {
            gestureDatabase = databasePath;
            this.videoPath = videoPath;

            if (kinectSensor == null)
            {
                throw new ArgumentNullException("kinectSensor");
            }

            if (gestureResultView == null)
            {
                throw new ArgumentNullException("gestureResultView");
            }
            
            this.GestureResultView = gestureResultView;
            
            // create the vgb source. The associated body tracking ID will be set when a valid body frame arrives from the sensor.
            this.vgbFrameSource = new VisualGestureBuilderFrameSource(kinectSensor, 0);
            this.vgbFrameSource.TrackingIdLost += this.Source_TrackingIdLost;

            // open the reader for the vgb frames
            this.vgbFrameReader = this.vgbFrameSource.OpenReader();
            if (this.vgbFrameReader != null)
            {
                this.vgbFrameReader.IsPaused = true;
                this.vgbFrameReader.FrameArrived += this.Reader_GestureFrameArrived;
            }

            // load the 'Seated' gesture from the gesture database
            using (VisualGestureBuilderDatabase database = new VisualGestureBuilderDatabase(this.gestureDatabase))
            {
                // we could load all available gestures in the database with a call to a, 
                // but for this program, we only want to track one discrete gesture from the database, so we'll load it by name

                /*foreach (Gesture gesture in database.AvailableGestures)
                {   
                    if (gesture.Name.Equals(this.gesturename))
                    {
                        this.vgbFrameSource.AddGesture(gesture);
                    }
                  
                }*/

                vgbFrameSource.AddGestures(database.AvailableGestures);

            }
        }

        /// <summary> Gets the GestureResultView object which stores the detector results for display in the UI </summary>
        public GestureResultView GestureResultView { get; private set; }

        /// <summary>
        /// Gets or sets the body tracking ID associated with the current detector
        /// The tracking ID can change whenever a body comes in/out of scope
        /// </summary>
        public ulong TrackingId
        {
            get
            {
                return this.vgbFrameSource.TrackingId;
            }

            set
            {
                if (this.vgbFrameSource.TrackingId != value)
                {
                    this.vgbFrameSource.TrackingId = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the detector is currently paused
        /// If the body tracking ID associated with the detector is not valid, then the detector should be paused
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return this.vgbFrameReader.IsPaused;
            }

            set
            {
                if (this.vgbFrameReader.IsPaused != value)
                {
                    this.vgbFrameReader.IsPaused = value;
                }
            }
        }

        /// <summary>
        /// Disposes all unmanaged resources for the class
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the VisualGestureBuilderFrameSource and VisualGestureBuilderFrameReader objects
        /// </summary>
        /// <param name="disposing">True if Dispose was called directly, false if the GC handles the disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.vgbFrameReader != null)
                {
                    this.vgbFrameReader.FrameArrived -= this.Reader_GestureFrameArrived;
                    this.vgbFrameReader.Dispose();
                    this.vgbFrameReader = null;
                }

                if (this.vgbFrameSource != null)
                {
                    this.vgbFrameSource.TrackingIdLost -= this.Source_TrackingIdLost;
                    this.vgbFrameSource.Dispose();
                    this.vgbFrameSource = null;
                }
            }
        }

        /// <summary>
        /// Handles gesture detection results arriving from the sensor for the associated body tracking Id
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_GestureFrameArrived(object sender, VisualGestureBuilderFrameArrivedEventArgs e)
        {
            VisualGestureBuilderFrameReference frameReference = e.FrameReference;
            using (VisualGestureBuilderFrame frame = frameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    // get the discrete gesture results which arrived with the latest frame
                    IReadOnlyDictionary<Gesture, DiscreteGestureResult> discreteResults = frame.DiscreteGestureResults;

                    if (discreteResults != null)
                    {
                        // we only have one gesture in this source object, but you can get multiple gestures
                        foreach (Gesture gesture in this.vgbFrameSource.Gestures)
                        {
                            if (gesture.Name.Equals(this.Gandalf[0]) && gesture.GestureType == GestureType.Discrete)
                            {

                               
                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.2f)
                                    {

                                        

                                        if (GandalfPr[1] == false && GandalfPr[2] == false && GandalfPr[3] == false)
                                        {

                                            GandalfPr[0] = true;
                                            GandalfPr[1] = false;
                                            GandalfPr[2] = false;
                                            GandalfPr[3] = false;

                                           // tmp.status(GandalfPr);

                                            //tmp.Show();
                                        }
                                    }


                                }
                            }
                       

                            
                            if (gesture.Name.Equals(this.Gandalf[1]) && gesture.GestureType == GestureType.Discrete)
                            {

                               
                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.2f)
                                    {
                                         if (GandalfPr[0] == true && GandalfPr[2]==false && GandalfPr[3]== false)
                                         {
                                            GandalfPr[1] = true;

                                           // tmp.status(GandalfPr);
                                            //tmp.Show();


                                          }
                                    }

                                }


                            }
                          
                         
                            if (gesture.Name.Equals(this.Gandalf[2]) && gesture.GestureType == GestureType.Discrete)
                            {

                               
                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.3f)
                                    {

                                        if (GandalfPr[0] == true && GandalfPr[1] == true && GandalfPr[3] == false)
                                        {
                                            GandalfPr[2] = true;
                                           // tmp.status(GandalfPr);
                                            //tmp.Show();

                                        }
                                    }
                                }


                            }
                      
                        
                            
                            if (gesture.Name.Equals(this.Gandalf[3]) && gesture.GestureType == GestureType.Discrete)
                            {

                                Console.Out.WriteLine("MEGPROBALOM FELISMERNI");
                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.3f)
                                    {


                                        if (GandalfPr[0] == true && GandalfPr[1] == true && GandalfPr[2] == true)
                                        {
                                            GandalfPr[3] = true;
                                           // tmp.status(GandalfPr);
                                            //tmp.Show();

                                        }
                                        if (GandalfPr[0] == true && GandalfPr[1] == true && GandalfPr[2] == true && GandalfPr[3] == true)
                                        {
                                            if (w1 == null)
                                            {
                                                w1 = new VideoPlayer();

                                                w1.Show();
                                                w1.playVideo(videoPath);
                                            }
                                        }


                                    }

                                    
                                }
                            }


                            if (gesture.Name.Equals(this.Goku[0]) && gesture.GestureType == GestureType.Discrete)
                            {


                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.3f)
                                    {

                                        if (GokuPr[1] == false)
                                        {
                                            GokuPr[0] = true;
                                           // tmp.status(GokuPr);
                                            //tmp.Show();
                                        }
                                        else
                                        {
                                            GandalfPr[0] = true;
                                            GandalfPr[1] = false;
                                        }
                                    }
                                }

                            }

                            if (gesture.Name.Equals(this.Goku[1]) && gesture.GestureType == GestureType.Discrete)
                            {


                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    // update the GestureResultView object with new gesture result values
                                    this.GestureResultView.UpdateGestureResult(true, result.Detected, result.Confidence);

                                    if (result.Confidence > 0.3f)
                                    {

                                        if (GokuPr[0] == true)
                                        {
                                            GokuPr[1] = true;
                                           // tmp.status(GokuPr);
                                            //tmp.Show();
                                        }
                                        if (GokuPr[0] == true && GokuPr[1] == true)
                                        {

                                            if (w1 == null)
                                            {
                                                w1 = new VideoPlayer();

                                                w1.Show();
                                                w1.playVideo(videoPath);
                                            }

                                        }
                                    }
                                }


                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the TrackingIdLost event for the VisualGestureBuilderSource object
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Source_TrackingIdLost(object sender, TrackingIdLostEventArgs e)
        {
            // update the GestureResultView object to show the 'Not Tracked' image in the UI
            this.GestureResultView.UpdateGestureResult(false, false, 0.0f);
        }
    }
}
