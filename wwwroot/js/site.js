﻿


// simple d3 visualizations for the previous years Scholarship information.
function uni() {
    // set the window size for each of the visualizations
    var margins = { top: 20, right: 20, bottom: 30, left: 40 };
    var width = 500 - margins.left - margins.right;
    var height = 250 - margins.top - margins.bottom;
    // create the xaxis line
    var x = d3.scaleBand()
        .range([0, width])
        .padding(0.1);
    // create the yaxis line
    var y = d3.scaleLinear()
        .range([height, 0]);
    // append the chart to one of the div elements on the page using selections
    var svg = d3.select(".chart1").append("svg")
        .attr("width", width + margins.left + margins.right)
        .attr("height", height + margins.top + margins.bottom + 75)
        .append("g")
        .attr("transform",
            "translate(" + margins.left + "," + margins.top + ")");

    // gridlines in y axis function
    function make_y_gridlines() {
        return d3.axisLeft(y)
            .ticks(10)
    }

    // add the Y gridlines
    svg.append("g")
        .attr("class", "grid")
        .call(make_y_gridlines()
            .tickSize(-width)
            .tickFormat("")
    );
    // load the data from the csv specified
    let promise = d3.csv("js/University.csv").then(function (data) {
        // cast the counts in the data from a string to a number.
        data.forEach(function (d) {
            d.count = +d.count;
        });
        console.log(data);
        // this is the colour scale for the charts
        var colorScale = ["#000004", "#1b0c41", "#4a0c6b", "#781c6d", "#a52c60", "#cf4446", "#ed6925", "#fb9b06", "#f7d13d", "#fcffa4"];

        // map the ticks onto the xaxis and their values
        x.domain(data.map(function (d) {
            return d.status;
        }));
        // map the y values to the axis
        y.domain([0, d3.max(data, function (d) {
            return d.count;
        }) + 20]);

        // draw the bars
        svg.selectAll(".bar")
            .data(data)
            .enter().append("rect")
            .attr("class", "bar")
            .attr("x", function (d) {
                return x(d.status);
            })
            .attr("width", x.bandwidth())
            .attr("y", function (d) {
                return y(d.count);
            })
            .attr("height", function (d) {
                return height - y(d.count);
            })
            .style("fill", function (d,i) {
                return colorScale[i + 1];
            });

        // append the xaxis labels
        svg.append("g")
            .attr("transform", "translate(0," + height + ")")
            .call(d3.axisBottom(x))
            .selectAll("text")
            .attr("y", 0)
            .attr("x", 9)
            .attr("dy", ".35em")
            .attr("transform", "rotate(45)")
            .style("text-anchor", "start");

        //append the yaxis labels
        svg.append("g")
            .call(d3.axisLeft(y));
        // append the chart label
        svg.append("text")
            .attr("x", width / 2)
            .attr("y", 0 - margins.top / 2)
            .attr("text-anchor", "middle")
            .style("font-family", "Consolas")
            .text("University");

        // simple event listener for the charts to have minimal interaction
        let domBars = document.getElementsByClassName("bar");
        for (let i = 0; i < domBars.length; i++) {
            let bar = domBars[i];
            bar.addEventListener("mouseenter", function () {
                d3.select(bar).transition().attr("fill", "red");
            });
            bar.addEventListener("mouseleave", function () {
                d3.select(bar).transition().attr("fill", "green");
            });
        }
    });
    console.log(promise);
}

// the comments in the chart above also apply to this chart
function department() {
    var margins = { top: 20, right: 20, bottom: 30, left: 40 };
    var width = 500 - margins.left - margins.right;
    var height = 250 - margins.top - margins.bottom;

    var x = d3.scaleBand()
        .range([0, width])
        .padding(0.1);

    var y = d3.scaleLinear()
        .range([height, 0]);

    var svg = d3.select(".chart1").append("svg")
        .attr("width", width + margins.left + margins.right)
        .attr("height", height + margins.top + margins.bottom + 75)
        .append("g")
        .attr("transform",
            "translate(" + margins.left + "," + margins.top + ")");

    // gridlines in y axis function
    function make_y_gridlines() {
        return d3.axisLeft(y)
            .ticks(10)
    }

    // add the Y gridlines
    svg.append("g")
        .attr("class", "grid")
        .call(make_y_gridlines()
            .tickSize(-width)
            .tickFormat("")
        );

    d3.csv("js/Department.csv").then(function (data) {

        data.forEach(function (d) {
            d.count = +d.count;
        });
        console.log(data);
        var colorScale = ["#002051", "#0d346b", "#33486e", "#575c6e", "#737172", "#8b8677", "#a49d78", "#c3b56d", "#e6cf59", "#fdea45"];

        x.domain(data.map(function (d) {
            return d.status;
        }));
        y.domain([0, d3.max(data, function (d) {
            return d.count;
        }) + 20]);

        svg.selectAll(".bar")
            .data(data)
            .enter().append("rect")
            .attr("class", "bar")
            .attr("x", function (d) {
                return x(d.status);
            })
            .attr("width", x.bandwidth())
            .attr("y", function (d) {
                return y(d.count);
            })
            .attr("height", function (d) {
                return height - y(d.count);
            })
            .style("fill", function (d, i) {
                return colorScale[i + 1];
            });

        svg.append("g")
            .attr("transform", "translate(0," + height + ")")
            .call(d3.axisBottom(x))
            .selectAll("text")
            .attr("y", 0)
            .attr("x", 9)
            .attr("dy", ".35em")
            .attr("transform", "rotate(45)")
            .style("text-anchor", "start");

        svg.append("g")
            .call(d3.axisLeft(y));

        svg.append("text")
            .attr("x", width / 2)
            .attr("y", 0 - margins.top / 2)
            .attr("text-anchor", "middle")
            .style("font-family", "Consolas")
            .text("Department");
    });
}

// the comments in the first chart also apply to this one too.
function nation() {
    var margins = { top: 20, right: 20, bottom: 30, left: 40 };
    var width = 500 - margins.left - margins.right;
    var height = 250 - margins.top - margins.bottom;

    var x = d3.scaleBand()
        .range([0, width])
        .padding(0.1);

    var y = d3.scaleLinear()
        .range([height, 0]);

    var svg = d3.select(".chart1").append("svg")
        .attr("width", width + margins.left + margins.right)
        .attr("height", height + margins.top + margins.bottom + 75)
        .append("g")
        .attr("transform",
            "translate(" + margins.left + "," + margins.top + ")");

    // gridlines in y axis function
    function make_y_gridlines() {
        return d3.axisLeft(y)
            .ticks(10)
    }

    // add the Y gridlines
    svg.append("g")
        .attr("class", "grid")
        .call(make_y_gridlines()
            .tickSize(-width)
            .tickFormat("")
        );

    d3.csv("js/Nation.csv").then(function (data) {

        data.forEach(function (d) {
            d.count = +d.count;
        });
        console.log(data);
        var colorScale = ["#8e0152", "#c51b7d", "#de77ae", "#f1b6da", "#fde0ef", "#e6f5d0", "#b8e186", "#7fbc41", "#4d9221", "#276419"];

        x.domain(data.map(function (d) {
            return d.status;
        }));
        y.domain([0, d3.max(data, function (d) {
            return d.count;
        }) + 20]);

        svg.selectAll(".bar")
            .data(data)
            .enter().append("rect")
            .attr("class", "bar")
            .attr("x", function (d) {
                return x(d.status);
            })
            .attr("width", x.bandwidth())
            .attr("y", function (d) {
                return y(d.count);
            })
            .attr("height", function (d) {
                return height - y(d.count);
            })
            .style("fill", function (d, i) {
                return colorScale[i + 1];
            });

        svg.append("g")
            .attr("transform", "translate(0," + height + ")")
            .call(d3.axisBottom(x))
            .selectAll("text")
            .attr("y", 0)
            .attr("x", 9)
            .attr("dy", ".35em")
            .attr("transform", "rotate(45)")
            .style("text-anchor", "start");

        svg.append("g")
            .call(d3.axisLeft(y));

        svg.append("text")
            .attr("x", width / 2)
            .attr("y", 0 - margins.top / 2)
            .attr("text-anchor", "middle")
            .style("font-family", "Consolas")
            .text("Nation");
    });

}    