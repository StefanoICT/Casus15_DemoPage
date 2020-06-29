using Face_demo.FaceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Windows;
using System.Windows.Input;
using System.Web.Script.Services;

namespace Face_demo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) {




            //var test = face.lookingAtBoard;
            //faceCounter.InnerText = facesCount.Result.ToString();
        }

        // <snippet_mainwindow_fields>
        // Add your Face subscription key to your environment variables.
        public static string subscriptionKey = Environment.GetEnvironmentVariable("https://scontent-amt2-1.xx.fbcdn.net/v/t1.0-9/89819397_1717413491752972_7501976112717627392_o.jpg?_nc_cat=102&_nc_sid=2d5d41&_nc_ohc=RnSQaqe8GfkAX_bE6QO&_nc_ht=scontent-amt2-1.xx&oh=9b8addfec330afa644fdd050961bd17b&oe=5EF242CB", EnvironmentVariableTarget.Process);
            // Add your Face endpoint to your environment variables.
            public static string faceEndpoint = Environment.GetEnvironmentVariable("https://faceidoriantation.cognitiveservices.azure.com/", EnvironmentVariableTarget.Process);

            public static readonly IFaceClient faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials("c39d7e49892c414c95ca137f450550da"),
                new System.Net.Http.DelegatingHandler[] { });

            // The list of detected faces.
            
            // The list of descriptions for the detected faces.
            public static string[] faceDescriptions;
            // The resize factor for the displayed image.
            public static double resizeFactor;
            //public List<Line> heatMap = new List<Line>();
            //public int lookingAtBoard = 0;

            public const string defaultStatusBarText =
                "Place the mouse pointer over a face to see the face description.";
            // </snippet_mainwindow_fields>

            // <snippet_mainwindow_constructor>

        // </snippet_mainwindow_constructor>

        // <snippet_browsebuttonclick_start>
        // Displays the image and calls UploadAndDetectFaces.
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static async Task<facesLooking> FaceOrient() {
            if (Uri.IsWellFormedUriString("https://faceidoriantation.cognitiveservices.azure.com/", UriKind.Absolute)) {
                faceClient.Endpoint = "https://faceidoriantation.cognitiveservices.azure.com/";
            }

            // Get the image file to scan from the user.

            //---CHANGE FILE HERE!!!---\\
            //faceList = await UploadAndDetectFaces("D:\\programming\\Face\\website\\Face demo\\Image\\image.jpg");
            IList<DetectedFace> faceList = null;
            // The list of Face attributes to return.
            IList<FaceAttributeType> faceAttributes =
                new FaceAttributeType[]
                {
                    //FaceAttributeType.Gender, FaceAttributeType.Age,
                    //FaceAttributeType.Smile, FaceAttributeType.Emotion,
                    //FaceAttributeType.Glasses, FaceAttributeType.Hair,
                    FaceAttributeType.HeadPose
                };
            // Call the Face API.
            try {
                using (Stream imageFileStream = File.OpenRead("D:\\programming\\Face\\website\\Face demo\\Image\\image.jpg")) {
                            //C:\\Users\Stefano\source\repos\Casus15_DemoPage\Face demo\Image\image.jpg
                            // The second argument specifies to return the faceId, while
                            // the third argument specifies not to return face landmarks.

                            faceList =
                                await faceClient.Face.DetectWithStreamAsync(
                                    imageFileStream, true, false, faceAttributes).ConfigureAwait(false);


                        }
                    }
                    // Catch and display Face API errors.
                    catch (APIErrorException f) {
                        Console.WriteLine(f.Message);
                        /*return*/
                        new List<DetectedFace>();
                    }
                    // Catch and display all other errors.
                    catch (Exception e) {
                        Console.WriteLine(e.Message, "Error");
                        //return new List<DetectedFace>();
                    }
            var faces = new facesLooking();
            faces.totalFaces = faceList.Count;
                    if (faceList.Count > 0) {
                        for (int i = 0; i < faceList.Count; ++i) {
                            DetectedFace face = faceList[i];
                            // Store the face description.
                            //faceDescriptions[i] = FaceDescription(face);

                            var Pitch = face.FaceAttributes.HeadPose.Pitch;
                            var Yaw = face.FaceAttributes.HeadPose.Yaw;
                            //var Roll = face.FaceAttributes.HeadPose.Roll;


                            Point vec = new Point(Convert.ToInt32(Yaw), Convert.ToInt32(Pitch));
                            //line.lineLineIntersection();

                            // Create points that define line.
                            Point point1 = new Point(face.FaceRectangle.Left + (face.FaceRectangle.Width / 2), face.FaceRectangle.Top + (face.FaceRectangle.Height / 2));
                            Point point2 = new Point(face.FaceRectangle.Left + vec.X * 100, face.FaceRectangle.Top + vec.Y * 100);
                            //int lookingToBoard = 0;
                            if (point2.Y < 0) {
                                Console.WriteLine("person is looking at screen");
                                faces.LookingAtScreen++;
                            }
                            else {
                                Console.WriteLine("NO");
                            }

                        }
                        return faces;
                    }
                    return null;
                    // </snippet_browsebuttonclick_mid>
                    // <snippet_browsebuttonclick_end>
                }
                // </snippet_browsebuttonclick_end>

                // <snippet_mousemove_start>
                // Displays the face description when the mouse is over a face rectangle.

                private static async Task<IList<DetectedFace>> UploadAndDetectFaces(string imageFilePath) {
            IList<DetectedFace> faceList;
                // The list of Face attributes to return.
                IList<FaceAttributeType> faceAttributes =
                    new FaceAttributeType[]
                    {
                    //FaceAttributeType.Gender, FaceAttributeType.Age,
                    //FaceAttributeType.Smile, FaceAttributeType.Emotion,
                    //FaceAttributeType.Glasses, FaceAttributeType.Hair,
                    FaceAttributeType.HeadPose
                    };
                // Call the Face API.
                try {
                    using (Stream imageFileStream = File.OpenRead(imageFilePath)) {
                        // The second argument specifies to return the faceId, while
                        // the third argument specifies not to return face landmarks.

                        faceList =
                            await faceClient.Face.DetectWithStreamAsync(
                                imageFileStream, true, false, faceAttributes).ConfigureAwait(false);

                        
                    }
                return faceList;
            }
                // Catch and display Face API errors.
                catch (APIErrorException f) {
                    Console.WriteLine(f.Message);
                    return new List<DetectedFace>();
                }
                // Catch and display all other errors.
                catch (Exception e) {
                    Console.WriteLine(e.Message, "Error");
                    return new List<DetectedFace>();
                }
            }
            // </snippet_uploaddetect>

            // <snippet_facedesc>
            // Creates a string out of the attributes describing the face.
            private static string FaceDescription(DetectedFace face) {
                StringBuilder sb = new StringBuilder();

                sb.Append("Face: ");
                sb.Append("Pitch:" + face.FaceAttributes.HeadPose.Pitch + "Yaw:" + face.FaceAttributes.HeadPose.Yaw + "Roll:" + face.FaceAttributes.HeadPose.Roll);

                // Return the built string.
                return sb.ToString();
            }
            // </snippet_facedesc>
            public static Point CountFacesLookingAtScreen(DetectedFace face) {
                //REFRANCE: https://stackoverflow.com/questions/16658529/pitch-and-yaw-to-2d-screen-coords

                var Pitch = face.FaceAttributes.HeadPose.Pitch;
                var Yaw = face.FaceAttributes.HeadPose.Yaw;
                //var Roll = face.FaceAttributes.HeadPose.Roll;


                Point vec = new Point(Convert.ToInt32(Yaw), Convert.ToInt32(Pitch));
                Line line = new Line();
                //line.lineLineIntersection();

                return vec;
            }
        }
        public class Line
        {
            public Point start;
            public Point end;
            public List<Point> line;
            string faceOwner;

            public Line(Point start, Point end) {
                this.start = start;
                this.end = end;
            }
            public Line() { }
            public Point lineLineIntersection(Point A, Point B, Point C, Point D) {
                // Line AB represented as a1x + b1y = c1  
                int a1 = B.Y - A.Y;
                int b1 = A.X - B.X;
                int c1 = a1 * (A.X) + b1 * (A.Y);

                // Line CD represented as a2x + b2y = c2  
                int a2 = D.Y - C.Y;
                int b2 = C.X - D.X;
                int c2 = a2 * (C.X) + b2 * (C.Y);

                int determinant = a1 * b2 - a2 * b1;

                if (determinant == 0) {
                    // The lines are parallel. This is simplified  
                    // by returning a pair of FLT_MAX  
                    return new Point(int.MaxValue, int.MaxValue);
                }

                int x = (b2 * c1 - b1 * c2) / determinant;
                int y = (a1 * c2 - a2 * c1) / determinant;
                if (x < end.X && y < end.Y) {
                    x = end.X;
                    y = end.Y;
                }
                if (x > start.X && y > start.Y) {
                    x = start.X;
                    y = start.Y;
                }
                return new Point(x, y);
            
        }
    }
    public class facesLooking
    {
        public int totalFaces;
        public int LookingAtScreen;

        public facesLooking(int faces, int looking) {
            this.totalFaces = faces;
            this.LookingAtScreen = looking;
        }
        public facesLooking() {
        }

    }

}