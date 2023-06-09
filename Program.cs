﻿using System;


namespace Assessment {

    //For Assessment Number 1
    class Clock {

        /*
           Analysis: 
           The physical appearance of an analogue clock is as follows: 
                1) Circular - meaning, it has 360 equal degrees
                2) 12 hour points and 60 minute points

            With this, each minute point has 360 / 60 = 6 degrees interval
            from the starting point (points at "12"). Therefore, calculating 
            the degrees of the minute hand is simply as follows:

                        Degrees of Minute Hand = 
                        minutes * 6 degrees

            
            On the other hand, the hour point has 360 / 12 = 30 degree interval. 
            Hence, the degrees of the hour hand is as follows:
                        
                        Degrees of Hour Hand = 
                        hours * 30 degrees

            However, as the minute progresses, the hour handle also progresses
            from one hour point to another. This means that it is possible
            for the hour handle to point in between two hour points, creating an
            extra degrees to be calculated.

            To solve for the excess, it is important to note that the minute
            hand must complete a whole revolution before the hour handle points to
            another hour point. For example, the hour handle points from "7" to "8"
            following a 60 minute interval. Thus, excess can be calculated by the 
            ratio of minutes to its whole multiplied by 30 degrees:

                    Excess Degrees = 
                    (minutes / 60) * 30

            Therefore, the degrees of hour handle is calculated by the following:

                    Degrees of Hour Hand = 
                    (hours + (minutes/60)) * 30

            
            To get the lesser degrees between the hour and minute handles:

                    Lesser Degrees = 
                    Abs(Degrees of Minutes - Degrees of Hours)
           */

        public static void solve(){

            Console.Write("Input analogue time in format HH:MM : ");
            string input = Console.ReadLine();

            if(input != null){
                string[] time = input.Split(":");
                
                //calculate degrees of minutes
                double minutes = double.Parse(time[1]);
                double degreesMins = minutes * 6.0;
                
                //calculate degrees of hours
                double degreesHours = ((double.Parse(time[0]) == 12.0 ? 0.0: double.Parse(time[0])) + (minutes/60)) * 30.0;

                //calculate lesser 
                //if minute hand is points at value lesser than hour (with respect to hours), the result inverts 
                double lesser =  Math.Abs(degreesMins - degreesHours) > 180 ? 360 - Math.Abs(degreesMins - degreesHours) : Math.Abs(degreesMins - degreesHours);
                Console.WriteLine("Lesser Degrees: {0}", Math.Round(lesser, 2));
            }

        }

    }

    //For Assessment Number 2
    class Branches{
        public List<Branches> branches = new List<Branches>();

        public Branches(List<Int32> children){
            if(children.Count > 0){
                //add children
                int num = children[0];
                children.RemoveAt(0);
                for(int i = 0; i < num; i++){
                    this.branches.Add(new Branches(children));
                }
            }
        }

        public int solveDepth(Branches branch){
            if(branch.branches.Count > 0){
                List<int> values = new List<int>();
                for(int i = 0; i < branch.branches.Count; i++){
                    int j = 1 + solveDepth(branch.branches[i]);
                    values.Add(j);
                }

                return values.Max();
            }
            else return 1;
        }

    }

    class Tree {
        public static void solve(){
            int[] childrenList = {2, 1, 0, 3, 1, 0, 2, 1, 0}; //manually entered number of children per parent
            Branches tree = new Branches(new List<int>(childrenList));
            int depth = tree.solveDepth(tree);
            Console.WriteLine("Depth of Structure: {0}", depth);
        }
    }
   

    //Main Program
    class Program {
        static void Main(string[] args) {

            int sel = 0;
            Console.Write("Please enter an assessment number (1 or 2): ");
            if(Int32.TryParse(Console.ReadLine(), out sel)){
                switch(sel){
                    case 1: Clock.solve(); break;
                    case 2: Tree.solve(); break;
                }
            }
        }

    }
}