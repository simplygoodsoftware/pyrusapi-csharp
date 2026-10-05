namespace PyrusApiClient
{
	/// <summary>
	/// Condition type. Unlike other enums, it is serialized as a number, not a string.
	/// </summary>
	/// <remarks>
	/// There is intentionally no <c>Unknown</c> member and no string enum converter here:
	/// an unrecognized number is kept as is.
	/// </remarks>
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
