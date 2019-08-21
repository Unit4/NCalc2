using System.Collections.Generic;

namespace NCalc.Domain
{
	public class Function : LogicalExpression
	{
		public Function(Identifier identifier, LogicalExpression[] expressions)
		{
            Identifier = identifier;
            Expressions = expressions;

            if (string.Compare(identifier.Name, "IF", true) == 0 && expressions.Length == 2)
            {
                var expressonsWithDefault = new List<LogicalExpression>(expressions);
                expressonsWithDefault.Add(new ValueExpression(0));
                Expressions = expressonsWithDefault.ToArray();
            }
        }

	    public Identifier Identifier { get; set; }

	    public LogicalExpression[] Expressions { get; set; }

	    public override void Accept(LogicalExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
