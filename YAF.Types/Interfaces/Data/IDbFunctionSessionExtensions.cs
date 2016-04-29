/* Yet Another Forum.NET
 * Copyright (C) 2003-2005 Bjørnar Henden
 * Copyright (C) 2006-2013 Jaben Cargman
 * Copyright (C) 2014-2016 Ingo Herbote
 * http://www.yetanotherforum.net/
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at

 * http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
namespace YAF.Types.Interfaces.Data
{
    #region Using

    using System.Data;

    #endregion

    /// <summary>
    ///     The db unit of work extensions.
    /// </summary>
    public static class IDbFunctionSessionExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The commit.
        /// </summary>
        /// <param name="dbFunctionSession">
        /// The db function session.
        /// </param>
        public static void Commit([NotNull] this IDbFunctionSession dbFunctionSession)
        {
            CodeContracts.VerifyNotNull(dbFunctionSession, "dbFunctionSession");

            if (dbFunctionSession.DbTransaction != null)
            {
                dbFunctionSession.DbTransaction.Commit();
            }
        }

        /// <summary>
        /// The rollback.
        /// </summary>
        /// <param name="dbFunctionSession">
        /// The db function session.
        /// </param>
        public static void Rollback([NotNull] this IDbFunctionSession dbFunctionSession)
        {
            CodeContracts.VerifyNotNull(dbFunctionSession, "dbFunctionSession");

            if (dbFunctionSession.DbTransaction != null)
            {
                dbFunctionSession.DbTransaction.Rollback();
            }
        }

        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="command">
        /// The command. 
        /// </param>
        /// <param name="dbTransaction">
        /// The db transaction. 
        /// </param>
        public static void Populate([NotNull] this IDbCommand command, IDbTransaction dbTransaction)
        {
            CodeContracts.VerifyNotNull(dbTransaction, "dbTransaction");
            CodeContracts.VerifyNotNull(command, "command");

            command.Connection = dbTransaction.Connection;
            command.Transaction = dbTransaction;
        }

        #endregion
    }
}