"use client";

import { TrendingUp } from "lucide-react";
import {
  Bar,
  BarChart,
  CartesianGrid,
  XAxis,
  YAxis,
  Legend,
  LabelList,
} from "recharts";

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  ChartConfig,
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent,
} from "@/components/ui/chart";

type ClientDetail = {
  name: string;
  totalResourceCount: number;
  activeResourceCount: number;
  inactiveResourceCount: number;
  // For non-projects usage, if needed.
  projectsCount?: number;
};

type BarChartComponentProps = {
  data: ClientDetail[];
  Title: string;
};

const chartConfig = {
  projects: {
    label: "Projects Count",
    color: "hsl(var(--chart-1))",
  },
} satisfies ChartConfig;

export function BarChartComponent({ data, Title }: BarChartComponentProps) {
  // Determine if we need to render the projects (stacked) chart
  const isProjects = Title.toLowerCase() === "projects";

  // Map data accordingly.
  const chartData = isProjects
    ? data.map((item) => ({
        name: item.name,
        active: item.activeResourceCount,
        inactive: item.inactiveResourceCount,
        total: item.totalResourceCount,
      }))
    : data.map((client) => ({
        name: client.name,
        projectsCount: client.projectsCount ?? 0,
      }));

      console.log(chartData)

  return (
    <Card className="w-96 h-96">
      <CardHeader>
        <CardTitle>
          {isProjects ? "Resources Per Projects" : `Projects Per ${Title}`}
        </CardTitle>
        <CardDescription>
          {isProjects
            ? "Overview of project counts"
            : "Overview of Project distribution"}
        </CardDescription>
      </CardHeader>
      <CardContent>
        <ChartContainer config={chartConfig}>
          <BarChart width={400} height={300} data={chartData}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="name" tickLine={false} />
            <YAxis/>
            <Legend />
            <ChartTooltip
              cursor={{ fill: "rgba(0, 0, 0, 0.1)" }}
              content={<ChartTooltipContent />}
            />
            {isProjects ? (
             <>
             <Bar
               dataKey="active"
               stackId="a"
               name="Active Resources"
               fill="hsl(var(--chart-2))"
             >
               {/* Attach the total label to the active bar */}
               <LabelList dataKey="total" position="top" />
             </Bar>
             <Bar
               dataKey="inactive"
               stackId="a"
               name="Inactive Resources"
               fill="hsl(var(--chart-3))"
             />
           </>
            ) : (
              <Bar
                dataKey="projectsCount"
                name="Projects Count"
                fill="hsl(var(--chart-1))"
              >
                <LabelList dataKey="projectsCount" position="top" />
              </Bar>
            )}
          </BarChart>
        </ChartContainer>
      </CardContent>
      <CardFooter className="flex-col items-start gap-2 text-sm">
        <div className="flex gap-2 font-medium leading-none">
          Clear breakdown of {isProjects ? "projects" : `resources by ${Title}`}{" "}
          <TrendingUp className="h-4 w-4" />
        </div>
        <div className="leading-none text-muted-foreground">
          Showing the total number of{" "}
          {isProjects ? "resources" : `Projects per ${Title}`}
        </div>
      </CardFooter>
    </Card>
  );
}
