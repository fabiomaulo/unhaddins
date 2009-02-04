using Antlr.Runtime;

namespace NHibernate.Hql.Ast.ANTLR
{
    public partial class HqlLexer
    {
        private bool _possibleId;

        public bool PossibleId
        {
            get { return _possibleId; } 
            set { _possibleId = value; }
        }

        public override IToken Emit()
        {
            HqlToken t = new HqlToken(input, 
                                      state.type, 
                                      state.channel,
                                      state.tokenStartCharIndex,
                                      CharIndex - 1);

            t.Line = state.tokenStartLine;
            t.Text = state.text;

            t.PossibleId = PossibleId;
            PossibleId = false;

            Emit(t);
            return t;
        }
    }
}
