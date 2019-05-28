/// <reference path="../../../assets/admin/libs/angular/angular.js" />
(function (app) {
    app.factory('commonService', commonService);

    function commonService() {
        return {
            getSeoTitle: getSeoTitle
        };

        function getSeoTitle(input) {
            if (input == undefined || input == '') {
                return '';
            }
            var slug = input.toLowerCase();

            //change all of the signed-characters into the unsigned-characters
            slug = slug.replace(/á|à|ả|ạ|â|ã|ấ|ầ|ẩ|ẫ|ẫ|ă|ắ|ằ|ặ|ẵ|ẳ/gi, 'a');
            slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
            slug = slug.replace(/í|ì|ỉ|ĩ|ị/gi, 'i');
            slug = slug.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
            slug = slug.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
            slug = slug.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
            slug = slug.replace(/đ/gi, 'd');

            //Delete all of the especial characters
            slug = slug.replace(/\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\,|\.|\?|\/|\<|\>|\'|\"|\:|\;|\_|\=/gi, '');

            //change white-space into "-"
            slug = slug.replace(/ /gi, "-");

            //change many of squence "-" into ont of the "-"
            slug = slug.replace(/\-\-/gi, '-');
            slug = slug.replace(/\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-\-\-/gi, '-');

            //delete the first and end of "-"
            slug = '@' + slug + '@';
            slug = slug.replace(/\@\-|\-\@|\@/gi, '');

            return slug;
        }
    }
})(angular.module('kaid.common'));