import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { object, string, safeParse } from "valibot";
import { Project } from "../../types";

// Définition du schéma de validation
const DocSchema = object({
  name: string(),
  projectId: string(),
});

const DocForm: React.FC = () => {
  const [projects, setProjects] = useState<Project[]>([]);

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await fetch("your-api-endpoint/projects");
        const data = await response.json();
        setProjects(data);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    };

    fetchProjects();
  }, []);

  const {
    register,
    handleSubmit,
    setError,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data: any) => {
    // Validation avec valibot
    const result = safeParse(DocSchema, data);

    if (!result.success) {
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
    formData.append("projectId", data.projectId);
    if (data.document && data.document[0]) {
      formData.append("document", data.document[0]);
    }

    try {
      const response = await fetch("your-api-endpoint/doc", {
        method: "POST",
        body: formData,
      });

      if (response.ok) {
        console.log("Documentation added successfully!");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className="container mx-auto px-6 py-8">
      <h2 className="text-2xl font-bold mb-6">Add New Documentation</h2>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="space-y-4 max-w-xl"
        encType="multipart/form-data"
      >
        {/* Upload Document */}
        <div>
          <label className="block text-sm font-medium text-gray-700">Document</label>
          <input
            type="file"
            accept=".pdf,.doc,.docx"
            {...register("document")}
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

        {/* Project Selection */}
        <div>
          <label className="block text-sm font-medium text-gray-700">Project</label>
          <select
            {...register("projectId")}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          >
            <option value="">Select a project</option>
            {projects.map((project) => (
              <option key={project.id} value={project.id}>
                {project.name}
              </option>
            ))}
          </select>
          {errors.projectId && typeof errors.projectId.message === "string" && (
            <p className="mt-1 text-sm text-red-600">{errors.projectId.message}</p>
          )}
        </div>

        {/* Submit Button */}
        <button
          type="submit"
          className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
        >
          Add Documentation
        </button>
      </form>
    </div>
  );
};

export default DocForm;
