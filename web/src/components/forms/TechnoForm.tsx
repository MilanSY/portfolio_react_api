import React from "react";
import { useForm } from "react-hook-form";
import { object, string, safeParse } from "valibot";

// Définition du schéma Valibot
const TechnologySchema = object({
  name: string(),
  description: string(),
  date: string(),
});

const TechnoForm: React.FC = () => {
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data: any) => {
    // Validation avec valibot
    const result = safeParse(TechnologySchema, data);

    if (!result.success) {
      // result.error.issues contient la liste des erreurs
      result.error.issues.forEach((issue) => {
        if (issue.path) {
          setError(issue.path.join("."), {
            type: "manual",
            message: issue.message,
          });
        }
      });
      return;
    }

    // Création du formData
    const formData = new FormData();
    formData.append("name", data.name);
    formData.append("description", data.description);
    formData.append("date", data.date);
    if (data.image && data.image[0]) {
      formData.append("image", data.image[0]);
    }

    try {
      const response = await fetch("your-api-endpoint/technology", {
        method: "POST",
        body: formData,
      });

      if (response.ok) {
        console.log("Technology added successfully!");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className="container mx-auto px-6 py-8">
      <h2 className="text-2xl font-bold mb-6">Add New Technology</h2>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="space-y-4 max-w-xl"
        encType="multipart/form-data"
      >
        {/* Image Upload */}
        <div>
          <label className="block text-sm font-medium text-gray-700">
            Image
          </label>
          <input
            type="file"
            accept="image/*"
            {...register("image")}
            className="mt-1 block w-full"
          />
        </div>

        {/* Name */}
        <div>
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            type="text"
            {...register("name")}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          />
          {errors.name && typeof errors.name.message === "string" && (
            <p className="mt-1 text-sm text-red-600">{errors.name.message}</p>
          )}
        </div>

        {/* Description */}
        <div>
          <label className="block text-sm font-medium text-gray-700">
            Description
          </label>
          <textarea
            {...register("description")}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          />
          {errors.description && typeof errors.description.message === "string" && (
            <p className="mt-1 text-sm text-red-600">{errors.description.message}</p>
          )}
        </div>

        {/* Date */}
        <div>
          <label className="block text-sm font-medium text-gray-700">Date</label>
          <input
            type="date"
            {...register("date")}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          />
          {errors.date && typeof errors.date.message === "string" && (
            <p className="mt-1 text-sm text-red-600">{errors.date.message}</p>
          )}
        </div>

        {/* Submit Button */}
        <button
          type="submit"
          className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
        >
          Add Technology
        </button>
      </form>
    </div>
  );
};

export default TechnoForm;
