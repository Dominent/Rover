using PlumGuide.Rover.Engine;
using System;
using System.Collections.Generic;

namespace PlumGuide.Rover.API.Models.Output
{
    public class SendCommandOutputModel
    {
        public Position Position { get; set; }

        public string[] Errors { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SendCommandOutputModel model &&
                   EqualityComparer<Position>.Default.Equals(Position, model.Position) &&
                   EqualityComparer<string[]>.Default.Equals(Errors, model.Errors);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, Errors);
        }
    }
}
