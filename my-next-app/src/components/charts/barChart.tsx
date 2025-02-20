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
  clientName: string;
  totalResourceCount: number;
  activeResourceCount: number;
  inactiveResourceCount: number;
};

type BarChartComponentProps = {
  data: {
    clientDetails: ClientDetail[];
  };
};

const chartConfig = {
  active: {
    label: "Active Resources",
    color: "hsl(var(--chart-2))",
  },
  inactive: {
    label: "Inactive Resources",
    color: "hsl(var(--chart-3))",
  },
} satisfies ChartConfig;

export function BarChartComponent({ data }: BarChartComponentProps) {
  // Map each client to a chart data object
  const chartData = data.clientDetails.map((client: ClientDetail) => ({
    client: client.clientName,
    total: client.totalResourceCount,
    active: client.activeResourceCount,
    inactive: client.inactiveResourceCount,
  }));
  
  return (
    <Card className="w-96 h-96">
      <CardHeader>
        <CardTitle>Projects Per Client</CardTitle>
        <CardDescription>Overview of project distribution</CardDescription>
      </CardHeader>
      <CardContent>
        <ChartContainer config={chartConfig}>
          <BarChart width={400} height={300} data={chartData}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="client" tickLine={false} />
            <YAxis />
            <Legend />
            <ChartTooltip
              cursor={{ fill: "rgba(0, 0, 0, 0.1)" }}
              content={<ChartTooltipContent />}
            />
            {/* Both bars share the same stackId to be rendered as a single stacked bar */}
            <Bar
              dataKey="active"
              stackId="a"
              name="Active Resources"
              fill="hsl(var(--chart-2))"
            />
            <Bar
              dataKey="inactive"
              stackId="a"
              name="Inactive Resources"
              fill="hsl(var(--chart-3))"
            >
              {/* LabelList displays the total count on top of the bar */}
              <LabelList dataKey="total" position="top" />
            </Bar>
          </BarChart>
        </ChartContainer>
      </CardContent>
      <CardFooter className="flex-col items-start gap-2 text-sm">
        <div className="flex gap-2 font-medium leading-none">
          Clear breakdown of projects by client{" "}
          <TrendingUp className="h-4 w-4" />
        </div>
        <div className="leading-none text-muted-foreground">
          Showing the total number of projects per client
        </div>
      </CardFooter>
    </Card>
  );
}
