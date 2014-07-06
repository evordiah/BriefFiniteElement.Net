﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BriefFiniteElementNet
{
    /// <summary>
    /// Represents a genral load that can apply to a node (include 3 force and 3 moments)
    /// </summary>
    [Serializable]
    public struct NodalLoad : ISerializable
    {
        public NodalLoad(Force force, LoadCase @case)
        {
            this.force = force;
            _case = @case;
        }

        private Force force;

        /// <summary>
        /// Gets or sets the force.
        /// </summary>
        /// <value>
        /// The magnitude of <see cref="NodalLoad"/>.
        /// </value>
        public Force Force
        {
            get { return force; }
            set { force = value; }
        }

        /// <summary>
        /// Gets or sets the case.
        /// </summary>
        /// <value>
        /// The Load case of <see cref="NodalLoad"/>.
        /// </value>
        public LoadCase Case
        {
            get { return _case; }
            set { _case = value; }
        }

        private LoadCase _case;



        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("force", force);
            info.AddValue("case", _case);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodalLoad"/> class. satisfies the constrictor for <see cref="ISerializable"/> interface.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        public NodalLoad(SerializationInfo info, StreamingContext context)
        {
            force = (Force) info.GetValue("force", typeof (Force));
            _case = (LoadCase) info.GetValue("case", typeof (LoadCase));
        }
    }
}
