function loginValidation(change_element_class = true) {

    var valid_form = true;

    if (!checkField('username', change_element_class, 'username-error', 'Required'))
        valid_form = false;
    if (!checkField('password', change_element_class, 'password-error', 'Required'))
        valid_form = false;

    return valid_form;
}