﻿using static DotRas.Internal.Interop.Ras;

namespace DotRas
{
    /// <summary>
    /// Represents connection options for a remote access service (RAS) connection.
    /// </summary>
    public class RasConnectionOptions
    {
        private readonly RASCF flags;

        internal RasConnectionOptions(RASCF flags)
        {
            this.flags = flags;
        }

        protected RasConnectionOptions()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the connection is available to all users.
        /// </summary>
        public virtual bool IsAvailableToAllUsers => flags.HasFlag(RASCF.AllUsers);

        /// <summary>
        /// Gets a value indicating whether the credentials used for the connection are the default credentials.
        /// </summary>
        public virtual bool IsUsingDefaultCredentials => flags.HasFlag(RASCF.GlobalCreds);

        /// <summary>
        /// Gets a value indicating whether the owner of the connection is known.
        /// </summary>
        public virtual bool IsOwnerKnown => flags.HasFlag(RASCF.OwnerKnown);

        /// <summary>
        /// Gets a value indicating whether the owner of the connection matches the current user.
        /// </summary>
        public virtual bool IsOwnerCurrentUser => flags.HasFlag(RASCF.OwnerMatch);
    }
}