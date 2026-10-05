namespace PyrusApiClient
{
	/// <summary>
	/// Тип условия. В отличие от остальных enum'ов, передаётся числом, а не строкой.
	/// </summary>
	public enum BpmnConditionType
	{
		More = 0,
		Less = 1,
		NotFilled = 2,
		Filled = 3,
		Mask = 4,
		Equals = 5,
		MoreOrEquals = 6,
		LessOrEquals = 7,
		NotEquals = 8,
		Desc = 9,
		Or = 10,
		And = 11,
		Undefined = 12,
		True = 13,
		False = 14,
		InRoles = 15,
		Includes = 16,
		NotAllIncludedIn = 17,
		MaskNotMatch = 18,
		BpmnCurrentNode = 19,
		BpmnApprovedNode = 20
	}
}
