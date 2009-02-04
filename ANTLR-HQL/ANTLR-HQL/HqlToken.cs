﻿using Antlr.Runtime;

namespace NHibernate.Hql.Ast.ANTLR
{
    /// <summary>
    /// A custom token class for the HQL grammar.
    /// </summary>
    public class HqlToken : CommonToken
    {
        /// <summary>
        /// True if this token could be an identifier.
        /// </summary>
        private bool _possibleId;

        /// <summary>
        /// The previous token type.
        /// </summary>
        private int _previousTokenType;
 
        /// <summary>
        /// Public constructor
        /// </summary>
        public HqlToken(ICharStream input, int type, int channel, int start, int stop) : base(input, type, channel, start, stop)
        {
        }

        /// <summary>
        /// Indicates if the token could be an identifier.
        /// </summary>
        public bool PossibleId
        {
            get { return _possibleId; }
            set { _possibleId = value; }
        }

        /// <summary>
        /// Gets or Sets the type of the token, remembering the previous type on Sets.
        /// </summary>
        public override int Type
        {
            get
            {
                return base.Type;
            }
            set
            {
                _previousTokenType = Type;
                base.Type = value;
            }
        }

        /// <summary>
        /// Returns the previous token type.
        /// </summary>
        public int PreviousType
        {
            get { return _previousTokenType; }
        }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>The debug string</returns>
        public override string ToString()
        {
            return "[\""
                    + Text
                    + "\",<" + Type + "> previously: <" + PreviousType + ">,line="
                    + Line + ",col="
                    + CharPositionInLine + ",possibleID=" + PossibleId + "]";
        }
    }
}