var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");

gulp.task("site", function () {
    return gulp.src('Styles/site.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("main", function () {
    return gulp.src('Styles/main.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});