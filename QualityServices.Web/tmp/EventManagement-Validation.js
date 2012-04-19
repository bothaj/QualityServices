Sys.Mvc.ValidatorRegistry.validators["guidRequired"] = function (rule) {

    // initialization code can go here.
    return function (value, element, parameters) {
        if (accept == "00000000-0000-0000-0000-000000000000")
            return false;
        else
            return true;
    };

    return rule.ErrorMessage;
};

Sys.Mvc.ValidatorRegistry.validators["requiredif"] = function (rule) {
    // initialization code can go here.
    var dependentProperty = rule.ValidationParameters["dependentProperty"];
    var targetValue = rule.ValidationParameters["targetValue"];

    if (targetValue == null)
        targetValue = '';
    else if (targetValue == '0')
        targetValue = ''
    else
        targetValue = targetValue.toString();

    return function (value, element, parameters) {
        // get the actual value of the target control
        var actualvalue = $('#' + dependentProperty).val();

        if (targetValue == actualvalue) {
            return $.trim(value).length > 0;
        }
        else {
            return true;
        }
    };

    return rule.ErrorMessage;
};

Sys.Mvc.ValidatorRegistry.validators["requiredifvalue"] = function (rule) {
    // initialization code can go here.
    var dependentProperty = rule.ValidationParameters["dependentProperty"];
    var targetValue = rule.ValidationParameters["targetValue"];
    var comparisonType = rule.ValidationParameters["comparisonType"]

    if (targetValue == null || targetValue.toString().length == 0)
        targetValue = 0;
    else
        targetValue = parseInt(targetValue);

    return function (value, element, parameters) {
        // get the actual value of the target control
        var dependantvalue = 0;
        if ($('#' + dependentProperty).val().length > 0) {
            dependantvalue = parseInt($('#' + dependentProperty).val());

            if (isNaN(dependantvalue))
                dependantvalue = 0;
        }

        if (comparisonType == "EqualTo") {
            if (targetValue == dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
        else if (comparisonType == "GreaterThan") {
            if (targetValue < dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
        else if (comparisonType == "LessThan") {
            if (targetValue > dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
    };

    return rule.ErrorMessage;
};

Sys.Mvc.ValidatorRegistry.validators["requiredifboolvalue"] = function (rule) {
    // initialization code can go here.
    var dependentProperty = rule.ValidationParameters["dependentProperty"];
    var targetValue = rule.ValidationParameters["targetValue"];
    var comparisonType = rule.ValidationParameters["comparisonType"]

    if (targetValue == null || targetValue.toString().length == 0)
        targetValue = 0;
    else
        targetValue = parseInt(targetValue);

    return function (value, element, parameters) {
        // get the actual value of the target control
        var dependantvalue = 0;
        if ($('#' + dependentProperty).val().length > 0) {
            dependantvalue = parseInt($('#' + dependentProperty).val());

            if (isNaN(dependantvalue))
                dependantvalue = 0;
        }

        if (comparisonType == "EqualTo") {
            if (targetValue == dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
        else if (comparisonType == "GreaterThan") {
            if (targetValue < dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
        else if (comparisonType == "LessThan") {
            if (targetValue > dependantvalue) {
                return $.trim(value).length > 0;
            }
            else {
                return true;
            }
        }
    };

    return rule.ErrorMessage;
};


Sys.Mvc.ValidatorRegistry.validators["stringMinLength"] = function (rule) {

    // initialization code can go here.
    var minLength = rule.ValidationParameters["MinLength"];
    var maxLength = rule.ValidationParameters["MaxLength"];

    return function (value, element, parameters) {
        if ($.trim(value).length > (minLength - 1) && $.trim(value).length < (maxLength + 1))
            return true;
        else
            return false;
    };

    return rule.ErrorMessage;
};


Sys.Mvc.ValidatorRegistry.validators["booleanRequired"] = function (rule) {

    // initialization code can go here.
    var required = rule.ValidationParameters["required"];

    return function (value, element, parameters) {
        var accept = element.fieldContext.elements[0].checked;
        if (accept == required)
            return true;
        else
            return false;
    };

    return rule.ErrorMessage;
};